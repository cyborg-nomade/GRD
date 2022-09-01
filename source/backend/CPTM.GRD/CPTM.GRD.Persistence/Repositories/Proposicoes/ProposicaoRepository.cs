using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Proposicoes;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Persistence.Repositories.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.Proposicoes;

public class ProposicaoRepository : GenericRepository<Proposicao>, IProposicaoRepository
{
    private readonly GrdContext _grdContext;
    private readonly IGroupRepository _groupRepository;

    public ProposicaoRepository(GrdContext grdContext) : base(grdContext)
    {
        _grdContext = grdContext;
        _groupRepository = new GroupRepository(grdContext);
    }

    public async Task<IReadOnlyList<Proposicao>> GetByStatus(ProposicaoStatus status, bool arquivada)
    {
        return await _grdContext.Proposicoes.Where(p => p.Status == status && p.Arquivada == arquivada).ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByUser(int uid)
    {
        return await _grdContext.Proposicoes.Where(p => p.Criador != null && p.Criador.Id == uid).ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByGroup(int gid)
    {
        var groupWithSubordinates = await _groupRepository.GetSubordinateGroups(gid);

        return await _grdContext.Proposicoes
            .Where(p => p.Area != null && groupWithSubordinates
                .Select(g => g.Id)
                .Contains(p.Area.Id))
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByUserAndStatus(int uid, ProposicaoStatus status, bool arquivada)
    {
        var user = await _grdContext.Users.FindAsync(uid);
        if (user == null) throw new NotFoundException(nameof(user), uid);
        return await _grdContext.Proposicoes
            .Where(p => p.Criador == user && p.Status == status && p.Arquivada == arquivada).ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByGroupAndStatus(int gid, ProposicaoStatus status, bool arquivada)
    {
        var groupWithSubordinates = await _groupRepository.GetSubordinateGroups(gid);

        return await _grdContext.Proposicoes.Where(p =>
                groupWithSubordinates.Contains(p.Area) && p.Status == status && p.Arquivada == arquivada)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByReuniao(int rid)
    {
        return await _grdContext.Proposicoes.Where(p => p.Reuniao != null && p.Reuniao.Id == rid).ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByReuniaoPrevia(int rid)
    {
        var reuniao = await _grdContext.Reunioes.FindAsync(rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), rid);
        return await _grdContext.Proposicoes
            .Where(p => reuniao.ProposicoesPrevia != null && p.Reuniao != null && p.Reuniao.Id == rid && reuniao
                .ProposicoesPrevia
                .Select(p2 => p2.Id)
                .Contains(p.Id))
            .ToListAsync();
    }

    public async Task<Proposicao?> GetWithReuniao(int pid)
    {
        return await _grdContext.Proposicoes.Where(p => p.Id == pid).Include(p => p.Reuniao).SingleOrDefaultAsync();
    }
}