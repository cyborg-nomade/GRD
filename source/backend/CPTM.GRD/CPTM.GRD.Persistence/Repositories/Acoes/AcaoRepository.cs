using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Domain.Acoes;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.Acoes;

public class AcaoRepository : GenericRepository<Acao>, IAcaoRepository
{
    private readonly GrdContext _grdContext;

    public AcaoRepository(GrdContext grdContext) : base(grdContext)
    {
        _grdContext = grdContext;
    }

    public async Task<IReadOnlyList<Acao>> GetByReuniao(int rid)
    {
        var reuniao = await _grdContext.Reunioes.FindAsync(rid);
        if (reuniao == null) throw new NotFoundException(nameof(reuniao), rid);
        return await _grdContext.Acoes.Where(a => a.Reunioes.Contains(reuniao)).ToListAsync();
    }
}