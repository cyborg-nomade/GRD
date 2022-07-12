using System.Text;
using KellermanSoftware.CompareNetObjects;

namespace CPTM.GRD.Application.Util;

public static class Differentiator
{
    public static string GetDifferenceString<T>(T oldObj, T newObj)
    {
        var sb = new StringBuilder();
        var propertyCount = typeof(T).GetProperties().Length;

        var basicComparison = new CompareLogic()
            { Config = new ComparisonConfig() { MaxDifferences = propertyCount } };
        List<Difference> diffs = basicComparison.Compare(oldObj, newObj).Differences;

        foreach (var diff in diffs)
        {
            sb.AppendLine("Property name:" + diff.PropertyName);
            sb.AppendLine("Old value:" + diff.Object1Value);
            sb.AppendLine("New value:" + diff.Object2Value + "\n");
        }

        return sb.ToString();
    }
}