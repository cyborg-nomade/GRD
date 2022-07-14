using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

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