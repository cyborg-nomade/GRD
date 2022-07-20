using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.Reunioes;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.Reunioes;

public class ReuniaoRepository : GenericRepository<Reuniao>, IReuniaoRepository
{
    private readonly GrdContext _grdContext;

    public ReuniaoRepository(GrdContext grdContext) : base(grdContext)
    {
        _grdContext = grdContext;
    }

    public async Task<IReadOnlyList<Reuniao>> GetByStatus(ReuniaoStatus status)
    {
        return await _grdContext.Reunioes.Where(r => r.Status == status).ToListAsync();
    }
}