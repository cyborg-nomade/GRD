using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Contracts.Persistence.AccessControl;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<List<Group>> GetSubordinateGroups(int gid);
}