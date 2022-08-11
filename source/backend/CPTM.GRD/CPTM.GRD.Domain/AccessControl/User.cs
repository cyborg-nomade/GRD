using CPTM.GRD.Common;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Domain.AccessControl;

public class User
{
    public int Id { get; set; }
    public string Nome { get; init; } = string.Empty;
    public string UsernameAd { get; init; } = string.Empty;
    public AccessLevel NivelAcesso { get; set; }
    public ICollection<Group> AreasAcesso { get; init; } = new List<Group>();
    public string Funcao { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public IEnumerable<Reuniao>? Reunioes { get; set; } = new List<Reuniao>();
    public IEnumerable<Reuniao>? Previas { get; set; } = new List<Reuniao>();
}