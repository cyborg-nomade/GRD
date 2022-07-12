namespace CPTM.GRD.Application.Persistence.Contracts.StrictSequenceControl;

public interface IGenericStrictSequenceControl
{
    Task<int> GetNextSequence();
}