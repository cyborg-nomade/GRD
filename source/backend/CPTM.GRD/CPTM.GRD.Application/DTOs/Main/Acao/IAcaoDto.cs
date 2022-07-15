using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao;

public interface IAcaoDto
{
    public TipoAcao Tipo { get; set; }
    public GroupDto DiretoriaRes { get; set; }
    public string Definicao { get; set; }
    public TipoPeriodicidadeAcao Periodicidade { get; set; }
    public DateOnly PrazoInicial { get; set; }
    public AcaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public UserDto Responsavel { get; set; }
    public string EmailDiretor { get; set; }
    public string? NumeroContrato { get; set; }
    public string? Fornecedor { get; set; }
    public int PrazoProrrogadoDias { get; set; }
    public DateOnly PrazoFinal { get; set; }
    public int DiasParaVencimento { get; set; }
    public TipoAlertaVencimento AlertaVencimento { get; set; }
}