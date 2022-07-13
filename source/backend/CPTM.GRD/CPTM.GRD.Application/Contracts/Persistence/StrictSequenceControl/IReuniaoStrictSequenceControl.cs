namespace CPTM.GRD.Application.Persistence.Contracts.StrictSequenceControl;

public interface IReuniaoStrictSequenceControl
{
    Task<int> GetNextNumeroReuniao();
}