using CPTM.GRD.Application.Contracts.Persistence.Reunioes.Children;
using CPTM.GRD.Domain.Reunioes.Children;

namespace CPTM.GRD.Persistence.Repositories.Reunioes.Children;

public class ParticipanteRepository : GenericRepository<Participante>, IParticipanteRepository
{
    public ParticipanteRepository(GrdContext grdContext) : base(grdContext)
    {
    }
}