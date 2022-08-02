using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Contracts.Persistence.AccessControl;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<IReadOnlyList<Group>> GetSubordinateGroups(int gid);
    Task<IReadOnlyList<Group>> GetSuperordinateGroups(int gid);
    Task<IReadOnlyList<Group>> GetByUser(int uid);
    Task<Group?> GetBySigla(string sigla);
    Task<Group> GetOrAddBySigla(string sigla);
    Task<bool> ExistsSigla(string sigla);
}