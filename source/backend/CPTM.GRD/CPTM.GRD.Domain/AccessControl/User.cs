namespace CPTM.GRD.Domain.AccessControl;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string UsernameAd { get; set; } = string.Empty;
    public AccessLevel NivelAcesso { get; set; }
    public ICollection<Group> AreasAcesso { get; set; } = new List<Group>();
    public string Funcao { get; set; } = string.Empty;
}