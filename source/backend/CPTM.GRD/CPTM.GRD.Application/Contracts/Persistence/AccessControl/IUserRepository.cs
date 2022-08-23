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
    Task<User> GetOrAddGerente(UsuarioAd usuarioAd);
    Task<User> GetOrAddDiretor(UsuarioAd usuarioAd);
    Task<User> GetOrAddGrgMember(UsuarioAd usuarioAd);
    Task<User> GetOrAddSysAdmin(UsuarioAd usuarioAd);
    Task<User> GetOrAdd(UsuarioAd usuarioAd, AccessLevel accessLevel);
    Task<User> AddFromUsuarioAd(UsuarioAd usuarioAd, AccessLevel accessLevel);
    Task<List<User>> GetFromIdList(ICollection<int> ids);
}