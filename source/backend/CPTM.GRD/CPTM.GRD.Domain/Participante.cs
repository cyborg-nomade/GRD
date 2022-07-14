using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain;

public class Participante
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public string DiretoriaArea { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}