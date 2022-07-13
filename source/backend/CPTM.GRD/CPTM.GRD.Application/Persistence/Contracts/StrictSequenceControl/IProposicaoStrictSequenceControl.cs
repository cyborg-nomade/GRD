namespace CPTM.GRD.Application.Persistence.Contracts.StrictSequenceControl;

public interface IProposicaoStrictSequenceControl
{
    Task<int> GetNextIdPrd();
}