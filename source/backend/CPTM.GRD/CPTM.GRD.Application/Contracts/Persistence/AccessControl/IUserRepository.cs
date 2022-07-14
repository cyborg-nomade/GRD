using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Contracts.Persistence.AccessControl;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IReadOnlyList<User>> GetByLevel(AccessLevel level);
    Task<IReadOnlyList<User>> GetByGroup(int gid);
    Task<IReadOnlyList<User>> GetByGroupAndLevel(int gid, AccessLevel level);
}