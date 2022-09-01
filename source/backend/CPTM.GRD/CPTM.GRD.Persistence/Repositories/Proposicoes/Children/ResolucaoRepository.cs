using CPTM.GRD.Application.Contracts.Persistence.Proposicoes.Children;
using CPTM.GRD.Domain.Proposicoes.Children;

namespace CPTM.GRD.Persistence.Repositories.Proposicoes.Children;

public class ResolucaoRepository : GenericRepository<Resolucao>, IResolucaoRepository
{
    public ResolucaoRepository(GrdContext grdContext) : base(grdContext)
    {
    }
}