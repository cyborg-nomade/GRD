using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.AccessControl;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly GrdContext _grdContext;

    public UserRepository(GrdContext grdContext) : base(grdContext)
    {
        _grdContext = grdContext;
    }

    public async Task<IReadOnlyList<User>> GetByLevel(AccessLevel level)
    {
        return await _grdContext.Users.Where(u => u.NivelAcesso == level).ToListAsync();
    }

    public async Task<IReadOnlyList<User>> GetByGroup(int gid)
    {
        var group = await _grdContext.Groups.FindAsync(gid);
        if (group == null) throw new NotFoundException(nameof(group), gid);
        return await _grdContext.Users.Where(u => u.AreasAcesso.Contains(group)).ToListAsync();
    }

    public async Task<IReadOnlyList<User>> GetByGroupAndLevel(int gid, AccessLevel level)
    {
        var group = await _grdContext.Groups.FindAsync(gid);
        if (group == null) throw new NotFoundException(nameof(group), gid);
        return await _grdContext.Users.Where(u => u.AreasAcesso.Contains(group) && u.NivelAcesso == level)
            .ToListAsync();
    }

    public async Task<User> GetByUsername(string username)
    {
        var user = await _grdContext.Users.Where(u => u.UsernameAd == username).SingleOrDefaultAsync();
        if (user == null) throw new NotFoundException(nameof(user), nameof(user));
        return user;
    }
}