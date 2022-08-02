using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Models.AD;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Contracts.Infrastructure;

public interface IAuthenticationService
{
    Task<bool> ExistsAd(string username);
    Task<bool> Authenticate(AuthUser user);
    Task<UsuarioAD> GetUsuarioAd(string username);
    Task<GrupoAD> GetGroupAd(string groupName);
    Task<bool> IsGerente(string username);
    Task<bool> IsDiretor(string username);
    string GenerateToken(User user);
}