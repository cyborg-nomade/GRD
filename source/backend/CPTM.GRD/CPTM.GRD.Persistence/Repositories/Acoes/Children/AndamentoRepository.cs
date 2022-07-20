using CPTM.GRD.Application.Contracts.Persistence.Acoes.Children;
using CPTM.GRD.Domain.Acoes.Children;

namespace CPTM.GRD.Persistence.Repositories.Acoes.Children;

public class AndamentoRepository : GenericRepository<Andamento>, IAndamentoRepository
{
    private readonly GrdContext _grdContext;

    public AndamentoRepository(GrdContext grdContext) : base(grdContext)
    {
        _grdContext = grdContext;
    }
}