using CPTM.GRD.Common;
using CPTM.GRD.Domain;

namespace CPTM.GRD.Application.Contracts.Persistence;

public interface IReuniaoRepository : IGenericRepository<Reuniao>
{
    Task<IReadOnlyList<Reuniao>> GetByStatus(ReuniaoStatus status);
}