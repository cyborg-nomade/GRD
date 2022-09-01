using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Acoes.Children;

public class Andamento
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public User? User { get; set; } = new User();
    public AndamentoStatus Status { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public ICollection<string> AnexosFilePaths { get; set; } = new List<string>();

    public Andamento()
    {
        Data = DateTime.Now;
    }
}