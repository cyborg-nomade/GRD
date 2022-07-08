using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Enum;
using CPTM.GRD.Domain.Logging;

namespace CPTM.GRD.Domain;

public class Acao
{
    public int Id { get; set; }
    public TipoAcao Tipo { get; set; }
    public Group DiretoriaRes { get; set; }
    public string Definicao { get; set; } = string.Empty;
    public TipoPeriodicidadeAcao Periodicidade { get; set; }
    public DateOnly PrazoInicial { get; set; }
    public AcaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public User Responsavel { get; set; } = new User();
    public string EmailDiretor { get; set; } = string.Empty;
    public string? NumeroContrato { get; set; }
    public string? Fornecedor { get; set; }
    public int PrazoProrrogadoDias { get; set; }
    public DateOnly PrazoFinal { get; set; }
    public int DiasParaVencimento { get; set; }
    public TipoAlertaVencimento AlertaVencimento { get; set; }
    public ICollection<Andamento> Andamentos { get; set; } = new List<Andamento>();
    public ICollection<LogAcao> Logs { get; set; } = new List<LogAcao>();
}