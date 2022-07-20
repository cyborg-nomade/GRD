using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Domain.Logging;

namespace CPTM.GRD.Persistence.Repositories.Logging;

public class LogProposicaoRepository : GenericRepository<LogProposicao>, ILogProposicaoRepository
{
    public LogProposicaoRepository(GrdContext grdContext) : base(grdContext)
    {
    }
}