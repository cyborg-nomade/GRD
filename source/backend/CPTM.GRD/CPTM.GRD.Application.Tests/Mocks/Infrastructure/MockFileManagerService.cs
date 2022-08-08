using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;
using Moq;

namespace CPTM.GRD.Application.Tests.Mocks.Infrastructure;

public static class MockFileManagerService
{
    public static Mock<IFileManagerService> GetFileManagerService()
    {
        var reuniao = It.IsAny<Reuniao>();
        var proposicao = It.IsAny<Proposicao>();

        var mockService = new Mock<IFileManagerService>();

        mockService.Setup(s => s.CreateAta(reuniao)).ReturnsAsync(@"C:\\homedir\file\file.txt");
        mockService.Setup(s => s.CreateMemoriaPrevia(reuniao)).ReturnsAsync(@"C:\\homedir\file\file.txt");
        mockService.Setup(s => s.CreatePautaDefinitiva(reuniao)).ReturnsAsync(@"C:\\homedir\file\file.txt");
        mockService.Setup(s => s.CreatePautaPrevia(reuniao)).ReturnsAsync(@"C:\\homedir\file\file.txt");
        mockService.Setup(s => s.CreateRelatorioDeliberativo(reuniao)).ReturnsAsync(@"C:\\homedir\file\file.txt");
        mockService.Setup(s => s.CreateResolucaoDiretoria(reuniao, proposicao))
            .ReturnsAsync(@"C:\\homedir\file\file.txt");

        return mockService;
    }
}