using CPTM.GRD.Common;

namespace CPTM.GRD.Application.Models;

public class TokenClaims
{
    public int Uid { get; set; }
    public AccessLevel NivelAcesso { get; set; }
    public ICollection<string> GruposAcesso { get; set; } = new List<string>();
}