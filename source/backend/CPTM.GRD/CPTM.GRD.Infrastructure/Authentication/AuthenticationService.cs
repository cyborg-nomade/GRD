using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Models;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public Task<bool> ExistsAd(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> Login(AuthUser user)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioAD> GetUsuarioAD(string username)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCodigoCPU(string username)
    {
        throw new NotImplementedException();
    }
}