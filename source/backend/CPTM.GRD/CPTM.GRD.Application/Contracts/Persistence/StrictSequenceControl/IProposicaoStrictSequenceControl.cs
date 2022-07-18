namespace CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;

public interface IProposicaoStrictSequenceControl
{
    Task<int> GetNextIdPrd();
    Task<bool> IsValid(int idprd);
}