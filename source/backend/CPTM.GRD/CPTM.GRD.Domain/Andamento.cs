using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Enum;

namespace CPTM.GRD.Domain;

public class Andamento
{
    public int Id { get; set; }
    public DateOnly Data { get; set; }
    public User? User { get; set; }
    public string NomeResponsavel { get; set; } = string.Empty;
    public AndamentoStatus Status { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public ICollection<string> AnexosFilePaths { get; set; } = new List<string>();
}