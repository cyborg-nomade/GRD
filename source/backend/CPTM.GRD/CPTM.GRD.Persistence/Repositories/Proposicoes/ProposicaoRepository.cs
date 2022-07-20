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
    private readonly GroupRepository _groupRepository;

    public ProposicaoRepository(GrdContext grdContext, GroupRepository groupRepository) : base(grdContext)
    {
        _grdContext = grdContext;
        _groupRepository = groupRepository;
    }

    public async Task<IReadOnlyList<Proposicao>> GetByStatus(ProposicaoStatus status, bool arquivada)
    {
        return await _grdContext.Proposicoes.Where(p => p.Status == status && p.Arquivada == arquivada).ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByUser(int uid)
    {
        var user = await _grdContext.Users.FindAsync(uid);
        if (user == null) throw new NotFoundException(nameof(user), uid);
        return await _grdContext.Proposicoes.Where(p => p.Criador == user).ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByGroup(int gid)
    {
        var groupWithSubordinates = await _groupRepository.GetSubordinateGroups(gid);

        return await _grdContext.Proposicoes.Where(p => groupWithSubordinates.Contains(p.AreaSolicitante))
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
                groupWithSubordinates.Contains(p.AreaSolicitante) && p.Status == status && p.Arquivada == arquivada)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByReuniao(int rid)
    {
        var reuniao = await _grdContext.Reunioes.FindAsync(rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), rid);
        return await _grdContext.Proposicoes.Where(p => p.Reuniao == reuniao).ToListAsync();
    }

    public async Task<IReadOnlyList<Proposicao>> GetByReuniaoPrevia(int rid)
    {
        var reuniao = await _grdContext.Reunioes.FindAsync(rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), rid);
        return await _grdContext.Proposicoes.Where(p => p.Reuniao == reuniao && reuniao.ProposicoesPrevia.Contains(p))
            .ToListAsync();
    }
}