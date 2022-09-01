namespace CPTM.GRD.Application.Models;

public class EmailArgs
{
    public string SistemaSigla { get; init; } = string.Empty;
    public string RementeNome { get; init; } = string.Empty;
    public string RemetenteEmail { get; init; } = string.Empty;
    public List<string> Destinatarios { get; init; } = new List<string>();
    public string Assunto { get; init; } = string.Empty;
    public string Mensagem { get; init; } = string.Empty;
    public DateTime EnviarEm { get; set; }
    public int IdUsuarioCpu { get; set; }
    public string MensagemErro { get; init; } = string.Empty;
    public Dictionary<string, byte[]>? Anexos { get; set; }
}