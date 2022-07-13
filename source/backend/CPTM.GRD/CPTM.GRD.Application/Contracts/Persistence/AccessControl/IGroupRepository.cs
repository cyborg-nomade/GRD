using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Persistence.Contracts.AccessControl;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<List<Group>> GetSubordinateGroups(int gid);
}