using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Logging;

namespace CPTM.GRD.Domain;

public class Proposicao
{
    public int Id { get; set; }
    public int IdPrd { get; set; }
    public ProposicaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
    public Group AreaSolicitante { get; set; } = new Group();
    public string Titulo { get; set; } = string.Empty;
    public ObjetoProposicao Objeto { get; set; }
    public string DescricaoProposicao { get; set; } = string.Empty;
    public bool PossuiParecerJuridico { get; set; }
    public string ResumoGeralResolucao { get; set; } = string.Empty;
    public string ObservacoesCustos { get; set; } = string.Empty;
    public string CompetenciasConformeNormas { get; set; } = string.Empty;
    public DateOnly DataBaseValor { get; set; }
    public string Moeda { get; set; } = string.Empty;
    public float ValorOriginalContrato { get; set; }
    public float ValorTotalProposicao { get; set; }
    public ReceitaDespesa ReceitaDespesa { get; set; }
    public string NumeroContrato { get; set; } = string.Empty;
    public string Termo { get; set; } = string.Empty;
    public string Fornecedor { get; set; } = string.Empty;
    public string ValorAtualContrato { get; set; } = string.Empty;
    public string NumeroReservaVerba { get; set; } = string.Empty;
    public float ValorReservaVerba { get; set; }
    public DateOnly InicioVigenciaReserva { get; set; }
    public DateOnly FimVigenciaReserva { get; set; }
    public string NumeroProposicao { get; set; } = string.Empty;
    public string ProtoloExpediente { get; set; } = string.Empty;
    public string NumeroProcessoLicit { get; set; } = string.Empty;
    public string? OutrasObservacoes { get; set; }
    public Reuniao Reuniao { get; set; } = new Reuniao();
    public string MotivoRetornoDiretoria { get; set; } = string.Empty;
    public string MotivoRetornoGrg { get; set; } = string.Empty;
    public string MotivoRetornoRd { get; set; } = string.Empty;
    public string Deliberacao { get; set; } = string.Empty;
    public ICollection<LogProposicao> Logs { get; set; } = new List<LogProposicao>();
    public Resolucao Resolucao { get; set; } = new Resolucao();
    public bool IsExtraPauta { get; set; }
    public string? NumeroConselho { get; set; }
    public string SinteseProcessoFilePath { get; set; } = string.Empty;
    public string NotaTecnicaFilePath { get; set; } = string.Empty;
    public string PrdFilePath { get; set; } = string.Empty;
    public string ParecerJuridicoFilePath { get; set; } = string.Empty;
    public string TrFilePath { get; set; } = string.Empty;
    public string RelatorioTecnicoFilePath { get; set; } = string.Empty;
    public string PlanilhaQuantFilePath { get; set; } = string.Empty;
    public string EditalFilePath { get; set; } = string.Empty;
    public string ReservaVerbaFilePath { get; set; } = string.Empty;
    public string ScFilePath { get; set; } = string.Empty;
    public string RavFilePath { get; set; } = string.Empty;
    public string CronogramaFisFinFilePath { get; set; } = string.Empty;
    public string PcaFilePath { get; set; } = string.Empty;
    public ICollection<string> OutrosFilePath { get; set; } = new HashSet<string>();
    public string AreaAtual { get; set; } = string.Empty;
    public string DescricaoFluxo { get; set; } = string.Empty;
    public string TempoPrevPerm { get; set; } = string.Empty;
    public string DescProxPasso { get; set; } = string.Empty;
    public string TempoPermProx { get; set; } = string.Empty;
    public int? Seq { get; set; }

    public Proposicao CalculateNewProposicaoStatusFromVotes()
    {
        var votes = Logs.Where(l => l.Tipo is TipoLogProposicao.AbstencaoRd or TipoLogProposicao.AprovacaoRd
            or TipoLogProposicao.SuspensaoRd or TipoLogProposicao.ReprovacaoRd).ToList();
        var voteCount = votes.Count;
        var approvedCount = votes.Count(l => l.Tipo == TipoLogProposicao.AprovacaoRd);
        var repprovedCount = votes.Count(l => l.Tipo == TipoLogProposicao.ReprovacaoRd);
        var suspensionCount = votes.Count(l => l.Tipo == TipoLogProposicao.SuspensaoRd);
        var abstentionCount = votes.Count(l => l.Tipo == TipoLogProposicao.AbstencaoRd);

        if (abstentionCount == voteCount)
        {
            Status = ProposicaoStatus.SuspensaRd;
            return this;
        }

        if (approvedCount > voteCount / 2)
        {
            Status = ProposicaoStatus.AprovadaRd;
        }

        return this;
    }
}