using System.Net;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Models;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;
using Microsoft.Extensions.Options;
using RestSharp;

namespace CPTM.GRD.Infrastructure.Email;

public class EmailService : IEmailService
{
    private const string AbiUrl = "http://localhost:7000/ABI/api/email/";
    private EmailSettings EmailSettings { get; }

    private readonly IAuthenticationService _authenticationService;

    public EmailService(IOptions<EmailSettings> emailOptions, IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        EmailSettings = emailOptions.Value;
    }

    public async Task<bool> SendEmail(User receiver, string assunto, string mensagem)
    {
        var args = new EmailArgs()
        {
            Assunto = assunto,
            Destinatarios = new List<string>() { receiver.Email },
            EnviarEm = DateTime.Now,
            IdUsuarioCpu = await _authenticationService.GetCodigoCPU(receiver.UsernameAd),
            Mensagem = mensagem,
            MensagemErro = "Houve um erro no envio do e-mail!",
            RementeNome = EmailSettings.Sender.Nome,
            RemetenteEmail = EmailSettings.Sender.Email,
            SistemaSigla = "GRD",
        };
        return await Send(args);
    }

    public async Task<bool> SendEmailWithFile(User receiver, Reuniao reuniao, TipoArquivo tipoArquivo)
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

        var fileData = await File.ReadAllBytesAsync(filePath);
        var fileName = Path.GetFileName(filePath);
        var anexos = new Dictionary<string, byte[]>()
        {
            { fileName, fileData }
        };

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

        var mensagem = tipoArquivo switch
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

        var args = new EmailArgs()
        {
            Assunto = assunto,
            Destinatarios = new List<string>() { receiver.Email },
            EnviarEm = DateTime.Now,
            IdUsuarioCpu = await _authenticationService.GetCodigoCPU(receiver.UsernameAd),
            Mensagem = $@"Prezados, 

Segue em anexo {mensagem} da Reunião de Diretoria número {reuniao.NumeroReuniao}.

Atenciosamente,
GRG",
            MensagemErro = "Houve um erro no envio do e-mail!",
            RementeNome = EmailSettings.Sender.Nome,
            RemetenteEmail = EmailSettings.Sender.Email,
            SistemaSigla = "GRD",
            Anexos = anexos
        };

        return await Send(args);
    }

    public async Task<bool> SendEmailWithFile(User receiver, Proposicao proposicao)
    {
        var filePath = proposicao.ResolucaoDiretoriaFilePath;
        var fileData = await File.ReadAllBytesAsync(filePath);
        var fileName = Path.GetFileName(filePath);
        var anexos = new Dictionary<string, byte[]>()
        {
            { fileName, fileData }
        };

        var args = new EmailArgs()
        {
            Assunto = $"Envio de Resolução de Diretoria para a Proposição IDPRD {proposicao.IdPrd}",
            Destinatarios = new List<string>() { receiver.Email },
            EnviarEm = DateTime.Now,
            IdUsuarioCpu = await _authenticationService.GetCodigoCPU(receiver.UsernameAd),
            Mensagem = $@"Prezados, 

Segue em anexo a Resolução de Diretoria para a Proposição IDPRD {proposicao.IdPrd}.

Atenciosamente,
GRG",
            MensagemErro = "Houve um erro no envio do e-mail!",
            RementeNome = EmailSettings.Sender.Nome,
            RemetenteEmail = EmailSettings.Sender.Email,
            SistemaSigla = "GRD",
            Anexos = anexos
        };

        return await Send(args);
    }

    private static async Task<bool> Send(EmailArgs args)
    {
        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, sslPolicyErrors) => true;

        var emailClient = new RestClient(AbiUrl + "enviar");


        var emailRequest = new RestRequest(AbiUrl, Method.Post);
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
}