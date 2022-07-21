using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Models;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Contracts.Infrastructure;

public interface IAuthenticationService
{
    Task<bool> ExistsAd(string username);
    Task<User> Login(AuthUser user);
    Task<UsuarioAD> GetUsuarioAD(string username);
    Task<int> GetCodigoCPU(string username);
}