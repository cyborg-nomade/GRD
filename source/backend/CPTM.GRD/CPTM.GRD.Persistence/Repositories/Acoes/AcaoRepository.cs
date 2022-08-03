using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Persistence.Repositories.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.Acoes;

public class AcaoRepository : GenericRepository<Acao>, IAcaoRepository
{
    private readonly GrdContext _grdContext;
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;

    public AcaoRepository(GrdContext grdContext
    ) : base(grdContext)
    {
        _grdContext = grdContext;
        _userRepository = new UserRepository(grdContext);
        _groupRepository = new GroupRepository(grdContext);
    }

    public async Task<IReadOnlyList<Acao>> GetByReuniao(int rid)
    {
        return await _grdContext.Acoes.Where(a => a.Reunioes.Select(r => r.Id).Contains(rid)).ToListAsync();
    }

    public async Task<IReadOnlyList<Acao>> GetByResponsavel(int uid)
    {
        return await _grdContext.Acoes.Where(a => a.Responsavel.Id == uid).ToListAsync();
    }

    public async Task<IReadOnlyList<Acao>> GetFromSubordinados(int suid)
    {
        var superior = await _userRepository.Get(suid);
        if (superior == null) throw new NotFoundException(nameof(superior), nameof(superior));

        var subordinateGroups = new List<Group>();
        foreach (var group in superior.AreasAcesso)
        {
            subordinateGroups.AddRange(await _groupRepository.GetSubordinateGroups(group.Id));
        }

        var subordinateGroupsIds = subordinateGroups.Distinct().Select(g => g.Id).ToList();

        var acoes = await _grdContext.Acoes
            .Where(a => subordinateGroupsIds.Intersect(a.Responsavel.AreasAcesso.Select(g => g.Id)).Any())
            .ToListAsync();

        return acoes;
    }
}