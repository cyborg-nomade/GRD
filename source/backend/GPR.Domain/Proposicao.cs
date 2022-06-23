namespace GPR.Domain;
public class Proposicao
{
  public int Id { get; set; }
  public ObjetoEnum Objeto { get; set; }
  public string NroProposicao { get; set; } = string.Empty;
  public string Protocolo { get; set; } = string.Empty;
  public string NroProcesso { get; set; } = string.Empty;
  public string NroReuniao { get; set; } = string.Empty;
  public DateTime DataRD { get; set; }
  public int Seq { get; set; }
  public int IdPRD { get; set; }
  public string Assunto { get; set; } = string.Empty;
  public string NroConselho { get; set; } = string.Empty;
  public string AreaSolicitante { get; set; } = string.Empty;
  public string MotivoRetorno { get; set; } = string.Empty;
  public bool shouldVincularPRD { get; set; }
  public bool isExtraPauta { get; set; }
  public AcaoEnum Acao { get; set; }
  public string SiglaGerencia { get; set; } = string.Empty;
  public string Gerencia { get; set; } = string.Empty;
  public string SiglaDiretoria { get; set; } = string.Empty;
  public string Diretoria { get; set; } = string.Empty;
  public string AreaAtual { get; set; } = string.Empty;
  public string DescricaoFluxo { get; set; } = string.Empty;
  public string TempoPrevPerm { get; set; } = string.Empty;
  public StatusEnum Status { get; set; }
  public string ProximoPasso { get; set; } = string.Empty;
  public string DescricaoProxPasso { get; set; } = string.Empty;
  public string TempoPermProx { get; set; } = string.Empty;
  public string Motivo { get; set; } = string.Empty;
  public string ProposicaoDesc { get; set; } = string.Empty;
  public string Relator { get; set; } = string.Empty;
  public DateTime DataBase { get; set; }
  public string Moeda { get; set; } = string.Empty;
  public float ValorOriginalContrato { get; set; }
  public float ValorTotalProposicao { get; set; }
  public string AnexoPRDCaminho { get; set; } = string.Empty;
  public string AnexoTRCaminho { get; set; } = string.Empty;
  public string AnexoParecerJuridicoCaminho { get; set; } = string.Empty;
  public string AnexoRelatorioTecnicoCaminho { get; set; } = string.Empty;
  public string AnexoPlanilhaQuantitativaCaminho { get; set; } = string.Empty;
  public string AnexoEditalCaminho { get; set; } = string.Empty;
  public string AnexoReservaVerbaCaminho { get; set; } = string.Empty;
  public string AnexoSCCaminho { get; set; } = string.Empty;
  public string AnexoRAVCaminho { get; set; } = string.Empty;
  public string AnexoCronogramaFFCaminho { get; set; } = string.Empty;
  public string AnexoPCACaminho { get; set; } = string.Empty;
  public List<string>? AnexoOutrosCaminhos { get; set; }
}
