using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Domain.Proposicoes.Children;

namespace CPTM.GRD.Persistence.Repositories.Proposicoes.Children;

public class VotoRepository : GenericRepository<Voto>, IVotoRepository
{
    public VotoRepository(GrdContext grdContext) : base(grdContext)
    {
    }
}