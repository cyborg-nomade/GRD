using CPTM.GRD.Common;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Application.Contracts.Persistence.Reunioes;

public interface IReuniaoRepository : IGenericRepository<Reuniao>
{
    Task<IReadOnlyList<Reuniao>> GetByStatus(ReuniaoStatus status);
    new Task<Reuniao?> Get(int rid);
}