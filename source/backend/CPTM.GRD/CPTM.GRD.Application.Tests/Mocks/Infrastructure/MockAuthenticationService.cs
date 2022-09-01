using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Models.AD;
using Moq;

namespace CPTM.GRD.Application.UnitTests.Mocks.Infrastructure;

public static class MockAuthenticationService
{
    public static Mock<IAuthenticationService> GetAuthenticationService()
    {
        var mockUsuarioAd = new UsuarioAd()
        {
            Nome = "Uriel"
        };

        var mockService = new Mock<IAuthenticationService>();

        mockService.Setup(s => s.GetUsuarioAd(It.IsAny<string>())).ReturnsAsync(mockUsuarioAd);

        mockService.Setup(s => s.ExistsAd(It.IsAny<string>())).ReturnsAsync(true);

        return mockService;
    }
}