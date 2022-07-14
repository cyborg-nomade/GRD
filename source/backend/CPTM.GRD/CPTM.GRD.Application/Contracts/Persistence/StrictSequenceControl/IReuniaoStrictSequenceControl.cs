namespace CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;

public interface IReuniaoStrictSequenceControl
{
    Task<int> GetNextNumeroReuniao();
}