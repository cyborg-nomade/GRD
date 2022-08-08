using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;
using Moq;

namespace CPTM.GRD.Application.Tests.Mocks.Infrastructure;

public static class MockEmailService
{
    public static Mock<IEmailService> GetEmailService()
    {
        var acao = It.IsAny<Acao>();
        var reuniao = It.IsAny<Reuniao>();
        var proposicao = It.IsAny<Proposicao>();
        var receivers = It.IsAny<List<User>>();
        var assunto = It.IsAny<string>();
        var mensagem = It.IsAny<string>();
        var tipoArquivo = It.IsAny<TipoArquivo>();


        var mockService = new Mock<IEmailService>();

        mockService.Setup(s =>
                s.SendEmail(acao, reuniao, assunto, mensagem))
            .ReturnsAsync(true);

        mockService.Setup(s =>
                s.SendEmail(receivers, assunto, mensagem))
            .ReturnsAsync(true);

        mockService.Setup(s =>
                s.SendEmail(proposicao, reuniao, assunto, mensagem))
            .ReturnsAsync(true);

        mockService.Setup(s =>
                s.SendEmail(proposicao, assunto, mensagem))
            .ReturnsAsync(true);

        mockService.Setup(s =>
                s.SendEmailWithFile(receivers, reuniao, tipoArquivo))
            .ReturnsAsync(true);

        mockService.Setup(s =>
                s.SendEmailWithFile(proposicao))
            .ReturnsAsync(true);

        return mockService;
    }
}