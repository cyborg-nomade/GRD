namespace CPTM.GRD.Application.Models;

public class EmailArgs
{
    public string SistemaSigla { get; set; } = string.Empty;
    public string RementeNome { get; set; } = string.Empty;
    public string RemetenteEmail { get; set; } = string.Empty;
    public List<string> Destinatarios { get; set; } = new List<string>();
    public string Assunto { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public DateTime EnviarEm { get; set; }
    public int IdUsuarioCpu { get; set; }
    public string MensagemErro { get; set; } = string.Empty;
    public Dictionary<string, byte[]>? Anexos { get; set; }
}