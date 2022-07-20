using CPTM.GRD.Application.Contracts.Persistence.Logging;
using CPTM.GRD.Domain.Logging;

namespace CPTM.GRD.Persistence.Repositories.Logging;

public class LogReuniaoRepository : GenericRepository<LogReuniao>, ILogReuniaoRepository
{
    public LogReuniaoRepository(GrdContext grdContext) : base(grdContext)
    {
    }
}