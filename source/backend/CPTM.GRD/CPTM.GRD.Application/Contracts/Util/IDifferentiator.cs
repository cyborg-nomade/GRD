namespace CPTM.GRD.Application.Contracts.Util;

public interface IDifferentiator
{
    public string GetDifferenceString<T>(T oldObj, T newObj);
}