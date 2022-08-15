using CPTM.GRD.Application.Contracts.Persistence.Acoes.Children;
using CPTM.GRD.Domain.Acoes.Children;

namespace CPTM.GRD.Persistence.Repositories.Acoes.Children;

public class AndamentoRepository : GenericRepository<Andamento>, IAndamentoRepository
{
    public AndamentoRepository(GrdContext grdContext) : base(grdContext)
    {
    }
}