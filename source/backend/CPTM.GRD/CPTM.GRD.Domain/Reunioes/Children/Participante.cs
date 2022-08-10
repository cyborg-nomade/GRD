using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Reunioes.Children;

public class Participante
{
    public int Id { get; set; }
    public User? User { get; set; } = new User();
    public Group Area { get; set; } = new Group();
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Reuniao> Reunioes { get; set; } = new List<Reuniao>();
    public ICollection<Reuniao> Previas { get; set; } = new List<Reuniao>();
}