using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;

namespace CPTM.GRD.Persistence.Repositories.StrictSequenceControl;

public class ProposicaoStrictSequenceControl : IProposicaoStrictSequenceControl
{
    public Task<int> GetNextIdPrd()
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsValid(int idprd)
    {
        throw new NotImplementedException();
    }
}