using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Models;
using Moq;

namespace CPTM.GRD.Application.Tests.Mocks.Infrastructure;

public static class MockAuthenticationService
{
    public static Mock<IAuthenticationService> GetAuthenticationService()
    {
        var mockUsuarioAd = new UsuarioAD()
        {
            Nome = "Uriel"
        };

        var mockService = new Mock<IAuthenticationService>();

        mockService.Setup(s => s.GetUsuarioAD("urielf")).ReturnsAsync(mockUsuarioAd);

        mockService.Setup(s => s.ExistsAd("urielf")).ReturnsAsync(true);

        return mockService;
    }
}