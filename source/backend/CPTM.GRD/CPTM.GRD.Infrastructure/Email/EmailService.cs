using System.Net;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.Models;
using CPTM.GRD.Application.Models.Settings;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;
using Microsoft.Extensions.Options;
using RestSharp;

namespace CPTM.GRD.Infrastructure.Email;

public class EmailService : IEmailService
{
    private EmailServiceSettings EmailServiceSettings { get; }

    private readonly IViewUsuarioRepository _viewUsuarioRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;

    public EmailService(
        IOptions<EmailServiceSettings> emailOptions,
        IViewUsuarioRepository viewUsuarioRepository,
        IGroupRepository groupRepository,
        IUserRepository userRepository,
        IAuthenticationService authenticationService)
    {
        _viewUsuarioRepository = viewUsuarioRepository;
        _groupRepository = groupRepository;
        _userRepository = userRepository;
        _authenticationService = authenticationService;
        EmailServiceSettings = emailOptions.Value;
    }

    public async Task<bool> SendEmail(IEnumerable<User> receivers, string assunto, string mensagem)
    {
        var args = await SetEmailArgs(receivers, assunto, mensagem);
        return await Send(args);
    }

    public async Task<bool> SendEmail(Proposicao proposicao, string assunto, string mensagem)
    {
        var destinatarios = await GetDestinatariosFromProposicao(proposicao);

        var args = await SetEmailArgs(destinatarios, assunto, mensagem);
        return await Send(args);
    }

    public async Task<bool> SendEmail(Proposicao proposicao, Reuniao reuniao, string assunto, string mensagem)
    {
        var destinatarios = new List<User>();
        destinatarios.AddRange(await GetDestinatariosFromProposicao(proposicao));
        destinatarios.AddRange(GetDestinatariosFromReuniao(reuniao));

        var args = await SetEmailArgs(destinatarios, assunto, mensagem);
        return await Send(args);
    }

    public async Task<bool> SendEmail(Acao acao, Reuniao reuniao, string assunto, string mensagem)
    {
        var destinatarios = new List<User>();
        destinatarios.AddRange(GetDestinatariosFromReuniao(reuniao));
        destinatarios.Add(acao.Responsavel);

        var args = await SetEmailArgs(destinatarios, assunto, mensagem);
        return await Send(args);
    }

    public async Task<bool> SendEmailWithFile(IEnumerable<User> receivers, Reuniao reuniao, TipoArquivo tipoArquivo)
    {
        var filePath = tipoArquivo switch
        {
            TipoArquivo.PautaPrevia => reuniao.PautaPreviaFilePath,
            TipoArquivo.MemoriaPrevia => reuniao.MemoriaPreviaFilePath,
            TipoArquivo.PautaDefinitiva => reuniao.PautaDefinitivaFilePath,
            TipoArquivo.RelatorioDeliberativo => reuniao.RelatorioDeliberativoFilePath,
            TipoArquivo.Ata => reuniao.AtaFilePath,
            TipoArquivo.ResolucaoDiretoria => throw new ArgumentOutOfRangeException(nameof(tipoArquivo), tipoArquivo,
                null),
            _ => throw new ArgumentOutOfRangeException(nameof(tipoArquivo), tipoArquivo, null)
        };

        var anexos = await GetAnexosDictionary(filePath);

        var assunto = tipoArquivo switch
        {
            TipoArquivo.PautaPrevia => $"Envio de Pauta Prévia da Reunião Número {reuniao.NumeroReuniao}",
            TipoArquivo.MemoriaPrevia => $"Envio de Memória da Prévia da Reunião Número {reuniao.NumeroReuniao}",
            TipoArquivo.PautaDefinitiva => $"Envio de Pauta Definitiva da Reunião Número {reuniao.NumeroReuniao}",
            TipoArquivo.RelatorioDeliberativo =>
                $"Envio do Relatório Deliberativo da Reunião Número {reuniao.NumeroReuniao}",
            TipoArquivo.Ata => $"Envio de Ata da Reunião Número {reuniao.NumeroReuniao}",
            TipoArquivo.ResolucaoDiretoria => throw new ArgumentOutOfRangeException(nameof(tipoArquivo), tipoArquivo,
                null),
            _ => throw new ArgumentOutOfRangeException(nameof(tipoArquivo), tipoArquivo, null)
        };

        var variableMensagem = tipoArquivo switch
        {
            TipoArquivo.PautaPrevia => "a Pauta Prévia",
            TipoArquivo.MemoriaPrevia => "a Memória da Prévia",
            TipoArquivo.PautaDefinitiva => "a Pauta Definitiva",
            TipoArquivo.RelatorioDeliberativo => "o Relatório Deliberativo",
            TipoArquivo.Ata => "a Ata",
            TipoArquivo.ResolucaoDiretoria => throw new ArgumentOutOfRangeException(nameof(tipoArquivo), tipoArquivo,
                null),
            _ => throw new ArgumentOutOfRangeException(nameof(tipoArquivo), tipoArquivo, null)
        };

        var mensagem =
            $"Prezados,\n\nSegue em anexo {variableMensagem} para a Reunião número {reuniao.NumeroReuniao}.\n\nAtenciosamente,\nGRG";

        var args = await SetEmailArgs(receivers, assunto, mensagem, anexos);

        return await Send(args);
    }

    public async Task<bool> SendEmailWithFile(Proposicao proposicao)
    {
        var destinatarios = new List<User>();
        destinatarios.AddRange(await GetDestinatariosFromProposicao(proposicao));
        destinatarios.AddRange(GetDestinatariosFromReuniao(proposicao.Reuniao));

        var filePath = proposicao.ResolucaoDiretoriaFilePath;
        var anexos = await GetAnexosDictionary(filePath);

        var assunto = $"Envio de Resolução de Diretoria para a Proposição IDPRD {proposicao.IdPrd}";
        var mensagem =
            $"Prezados,\n\nSegue em anexo a Resolução de Diretoria para a Proposição IDPRD {proposicao.IdPrd}.\n\nAtenciosamente,\nGRG";

        var args = await SetEmailArgs(destinatarios, assunto, mensagem, anexos);

        return await Send(args);
    }

    private async Task<bool> Send(EmailArgs args)
    {
        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, sslPolicyErrors) => true;

        var emailClient = new RestClient(EmailServiceSettings.AbiUrl + "enviar");


        var emailRequest = new RestRequest
        {
            Method = Method.Post
        };
        emailRequest.AddHeader("Content-Type", "application/json");
        emailRequest.AddJsonBody(args);
        var response = await emailClient.ExecuteAsync(emailRequest);
        var enviado = response.IsSuccessful;

        if (enviado)
        {
            return true;
        }

        throw response.ErrorException!;
    }

    private static IEnumerable<User> GetDestinatariosFromReuniao(Reuniao reuniao)
    {
        var destinatariosReuniao = reuniao.Participantes.Select(p => p.User).ToList();
        return destinatariosReuniao;
    }

    private async Task<List<User>> GetDestinatariosFromProposicao(Proposicao proposicao)
    {
        var destinarioGroups = await _groupRepository.GetSuperordinateGroups(proposicao.AreaSolicitante.Id);
        var destinatarios = new List<User>();
        foreach (var group in destinarioGroups)
        {
            var destinatario = await _userRepository.GetByGroup(group.Id);
            destinatarios.AddRange(destinatario);
        }

        return destinatarios;
    }

    private static async Task<Dictionary<string, byte[]>> GetAnexosDictionary(string filePath)
    {
        var fileData = await File.ReadAllBytesAsync(filePath);
        var fileName = Path.GetFileName(filePath);
        var anexos = new Dictionary<string, byte[]>()
        {
            { fileName, fileData }
        };
        return anexos;
    }

    private async Task<EmailArgs> SetEmailArgs(IEnumerable<User> receivers, string assunto, string mensagem,
        Dictionary<string, byte[]>? anexos = null)
    {
        var destinatarios = receivers.Select(r => r.Email).ToList();
        destinatarios.Add(EmailServiceSettings.GrgMail);
        var destinatariosWithoutDuplicates = destinatarios.Distinct().ToList();
        var senderUsuarioAd = await _authenticationService.GetUsuarioAd(EmailServiceSettings.SenderUsernameAd);
        var args = new EmailArgs()
        {
            Assunto = assunto,
            Destinatarios = destinatariosWithoutDuplicates,
            EnviarEm = DateTime.Now,
            IdUsuarioCpu = await _viewUsuarioRepository.GetCodigoCPU(EmailServiceSettings.SenderUsernameAd),
            Mensagem = mensagem,
            MensagemErro = "Houve um erro no envio do e-mail!",
            RementeNome = senderUsuarioAd.Nome,
            RemetenteEmail = senderUsuarioAd.Email,
            SistemaSigla = "GRD",
            Anexos = anexos
        };
        return args;
    }
}