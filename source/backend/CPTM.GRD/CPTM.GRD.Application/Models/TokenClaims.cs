using CPTM.GRD.Common;

namespace CPTM.GRD.Application.Models;

public class TokenClaims
{
    public int Uid { get; init; }
    public AccessLevel NivelAcesso { get; init; }
    public ICollection<string> GruposAcesso { get; init; } = new List<string>();
}