using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(IEnumerable<User> receivers, string assunto, string mensagem);
    Task<bool> SendEmail(Proposicao proposicao, string assunto, string mensagem);
    Task<bool> SendEmail(Proposicao proposicao, Reuniao reuniao, string assunto, string mensagem);
    Task<bool> SendEmail(Acao acao, Reuniao reuniao, string assunto, string mensagem);
    Task<bool> SendEmailWithFile(IEnumerable<User> receivers, Reuniao reuniao, TipoArquivo tipoArquivo);
    Task<bool> SendEmailWithFile(Proposicao proposicao);
}