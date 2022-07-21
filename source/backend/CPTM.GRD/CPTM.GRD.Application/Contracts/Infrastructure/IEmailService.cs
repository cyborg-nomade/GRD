using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(User receiver, string assunto, string mensagem);
    Task<bool> SendEmailWithFile(User receiver, Reuniao reuniao, TipoArquivo tipoArquivo);
    Task<bool> SendEmailWithFile(User receiver, Proposicao proposicao);
}