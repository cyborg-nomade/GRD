using CPTM.GRD.Common;
using CPTM.GRD.Domain;

namespace CPTM.GRD.Application.Persistence.Contracts;

public interface IReuniaoRepository : IGenericRepository<Reuniao>
{
    Task<IReadOnlyList<Reuniao>> GetByStatus(ReuniaoStatus status);
}