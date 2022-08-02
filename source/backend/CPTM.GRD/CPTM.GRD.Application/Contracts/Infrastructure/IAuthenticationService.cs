using System.Security.Claims;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Models.AD;
using CPTM.GRD.Application.Responses;
using CPTM.GRD.Common;
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
    Task<bool> IsGrgMember(string username);
    bool IsSysAdmin(string username);
    AuthResponse GenerateToken(User user);
    bool AuthorizeByMinLevel(ClaimsPrincipal requestUser, AccessLevel accessLevel);
    Task<bool> AuthorizeByGroups(ClaimsPrincipal requestUser, ICollection<Group> areasAcesso);
}