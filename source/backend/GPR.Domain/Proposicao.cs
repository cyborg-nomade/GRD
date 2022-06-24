namespace GPR.Domain;

public class Proposicao
{
    public int Id { get; set; }
    public ObjetoEnum Objeto { get; set; }
    public string NroProposicao { get; set; } = string.Empty;
    public string Protocolo { get; set; } = string.Empty;
    public string NroProcesso { get; set; } = string.Empty;
    public string NroReuniao { get; set; } = string.Empty;
    public DateTime DataRd { get; set; }
    public int Seq { get; set; }
    public int IdPrd { get; set; }
    public string Assunto { get; set; } = string.Empty;
    public string NroConselho { get; set; } = string.Empty;
    public string AreaSolicitante { get; set; } = string.Empty;
    public string MotivoRetorno { get; set; } = string.Empty;
    public bool ShouldVincularPrd { get; set; }
    public bool IsExtraPauta { get; set; }
    public AcaoEnum Acao { get; set; }
    public string SiglaGerencia { get; set; } = string.Empty;
    public string Gerencia { get; set; } = string.Empty;
    public string SiglaDiretoria { get; set; } = string.Empty;
    public string Diretoria { get; set; } = string.Empty;
    public string AreaAtual { get; set; } = string.Empty;
    public string DescricaoFluxo { get; set; } = string.Empty;
    public string TempoPrevPerm { get; set; } = string.Empty;
    public StatusProposicaoEnum Status { get; set; }
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
    public string AnexoPrdCaminho { get; set; } = string.Empty;
    public string AnexoTrCaminho { get; set; } = string.Empty;
    public string AnexoParecerJuridicoCaminho { get; set; } = string.Empty;
    public string AnexoRelatorioTecnicoCaminho { get; set; } = string.Empty;
    public string AnexoPlanilhaQuantitativaCaminho { get; set; } = string.Empty;
    public string AnexoEditalCaminho { get; set; } = string.Empty;
    public string AnexoReservaVerbaCaminho { get; set; } = string.Empty;
    public string AnexoScCaminho { get; set; } = string.Empty;
    public string AnexoRavCaminho { get; set; } = string.Empty;
    public string AnexoCronogramaFfCaminho { get; set; } = string.Empty;
    public string AnexoPcaCaminho { get; set; } = string.Empty;
    public List<string>? AnexoOutrosCaminhos { get; set; }
}