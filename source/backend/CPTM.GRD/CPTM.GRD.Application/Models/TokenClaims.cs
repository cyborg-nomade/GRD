using CPTM.GRD.Common;

namespace CPTM.GRD.Application.Models;

public class TokenClaims
{
    public int Uid { get; set; }
    public AccessLevel NivelAcesso { get; init; }
    public ICollection<string> GruposAcesso { get; init; } = new List<string>();
}