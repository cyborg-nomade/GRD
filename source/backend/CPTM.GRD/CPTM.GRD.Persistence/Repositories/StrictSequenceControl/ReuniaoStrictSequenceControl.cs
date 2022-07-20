using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;

namespace CPTM.GRD.Persistence.Repositories.StrictSequenceControl;

public class ReuniaoStrictSequenceControl : IReuniaoStrictSequenceControl
{
    public Task<int> GetNextNumeroReuniao()
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsValid(int numeroReuniao)
    {
        throw new NotImplementedException();
    }
}