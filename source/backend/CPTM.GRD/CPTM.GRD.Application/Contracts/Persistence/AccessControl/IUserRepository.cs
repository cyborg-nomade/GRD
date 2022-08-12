using CPTM.GRD.Application.Models.AD;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Contracts.Persistence.AccessControl;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IReadOnlyList<User>> GetByLevel(AccessLevel level);
    Task<IReadOnlyList<User>> GetByGroup(int gid);
    Task<IReadOnlyList<User>> GetByGroupAndLevel(int gid, AccessLevel level);
    Task<User?> GetByUsername(string username);
    Task<bool> ExistsUsername(string username);
    Task<User> GetOrAddGerente(UsuarioAD usuarioAd);
    Task<User> GetOrAddDiretor(UsuarioAD usuarioAd);
    Task<User> GetOrAddGrgMember(UsuarioAD usuarioAd);
    Task<User> GetOrAddSysAdmin(UsuarioAD usuarioAd);
    Task<User> GetOrAdd(UsuarioAD usuarioAd, AccessLevel accessLevel);
    Task<User> AddFromUsuarioAd(UsuarioAD usuarioAd, AccessLevel accessLevel);
    Task<List<User>> GetFromIdList(ICollection<int> ids);
}