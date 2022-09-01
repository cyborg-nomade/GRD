using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Persistence.Repositories.Views;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.AccessControl;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    private readonly GrdContext _grdContext;
    private readonly IViewEstruturaRepository _viewEstruturaRepository;

    public GroupRepository(GrdContext grdContext) : base(grdContext)
    {
        _grdContext = grdContext;
        _viewEstruturaRepository = new ViewEstruturaRepository(grdContext);
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

        return returnGroups.Distinct().ToList();
    }

    public async Task<IReadOnlyList<Group>> GetSuperordinateGroups(int gid)
    {
        var mainGroup = await _grdContext.Groups.FindAsync(gid);
        if (mainGroup == null) throw new NotFoundException(nameof(mainGroup), gid);

        var returnGroups = new List<Group>() { mainGroup };

        if (mainGroup.CheckIsDiretoria())
        {
        }
        else if (mainGroup.CheckIsGerencia())
        {
            var superordinateGroups =
                await _grdContext.Groups.Where(g => g.Sigla == mainGroup.SiglaDiretoria).ToListAsync();
            returnGroups.AddRange(superordinateGroups);
        }
        else
        {
            var superordinateGroups =
                await _grdContext.Groups
                    .Where(g => g.Sigla == mainGroup.SiglaDiretoria || g.Sigla == mainGroup.SiglaGerencia)
                    .ToListAsync();
            returnGroups.AddRange(superordinateGroups);
        }

        var grg = await GetOrAddBySigla("GRG");
        returnGroups.Add(grg);

        return returnGroups.Distinct().ToList();
    }

    public async Task<IReadOnlyList<Group>> GetByUser(int uid)
    {
        return await _grdContext.Users.Where(u => u.Id == uid).SelectMany(u => u.AreasAcesso).ToListAsync();
    }

    public async Task<Group?> GetBySigla(string sigla)
    {
        var group = await _grdContext.Groups.Where(g => g.Sigla == sigla).SingleOrDefaultAsync();
        return group;
    }

    public async Task<Group> GetOrAddBySigla(string sigla)
    {
        if (await ExistsSigla(sigla))
        {
            var group = await GetBySigla(sigla);
            if (group == null) throw new NotFoundException(nameof(group), sigla);
            return group;
        }

        var grupo = await _viewEstruturaRepository.GetGroup(sigla);
        return await Add(grupo);
    }

    public async Task<bool> ExistsSigla(string sigla)
    {
        var group = await GetBySigla(sigla);
        return group != null;
    }
}