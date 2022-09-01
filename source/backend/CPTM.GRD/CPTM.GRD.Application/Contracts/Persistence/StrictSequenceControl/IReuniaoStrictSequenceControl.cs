namespace CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;

public interface IReuniaoStrictSequenceControl
{
    Task<int> GetNextNumeroReuniao();
    Task<bool> IsValid(int numeroReuniao);
}