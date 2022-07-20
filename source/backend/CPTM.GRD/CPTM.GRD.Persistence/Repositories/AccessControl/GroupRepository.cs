using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Domain.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.AccessControl;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    private readonly GrdContext _grdContext;

    public GroupRepository(GrdContext grdContext) : base(grdContext)
    {
        _grdContext = grdContext;
    }

    public async Task<IReadOnlyList<Group>> GetSubordinateGroups(int gid)
    {
        var mainGroup = await _grdContext.Groups.FindAsync(gid);
        if (mainGroup == null) throw new NotFoundException(nameof(mainGroup), gid);

        var returnGroups = new List<Group>() { mainGroup };

        if (mainGroup.CheckIsDiretoria())
        {
            var subordinateGroups =
                await _grdContext.Groups.Where(g => g.SiglaDiretoria == mainGroup.Sigla).ToListAsync();
            returnGroups.AddRange(subordinateGroups);
        }
        else if (mainGroup.CheckIsGerencia())
        {
            var subordinateGroups =
                await _grdContext.Groups.Where(g => g.SiglaGerencia == mainGroup.Sigla).ToListAsync();
            returnGroups.AddRange(subordinateGroups);
        }

        return returnGroups;
    }

    public async Task<IReadOnlyList<Group>> GetByUser(int uid)
    {
        return await _grdContext.Users.Where(u => u.Id == uid).SelectMany(u => u.AreasAcesso).ToListAsync();
    }
}