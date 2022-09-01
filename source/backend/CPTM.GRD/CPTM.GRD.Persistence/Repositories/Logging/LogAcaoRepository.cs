using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Domain.Logging;

namespace CPTM.GRD.Persistence.Repositories.Logging;

public class LogAcaoRepository : GenericRepository<LogAcao>, ILogAcaoRepository
{
    public LogAcaoRepository(GrdContext grdContext) : base(grdContext)
    {
    }
}