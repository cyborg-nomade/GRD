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
    public User Criador { get; set; } = new User();
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
    public string AnotacoesPrevia { get; set; } = string.Empty;
    public List<Voto> VotosRd { get; set; } = new List<Voto>();
    public string AjustesRd { get; set; } = string.Empty;
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
    public string ResolucaoDiretoriaFilePath { get; set; } = string.Empty;
    public string AreaAtual { get; set; } = string.Empty;
    public string DescricaoFluxo { get; set; } = string.Empty;
    public string TempoPrevPerm { get; set; } = string.Empty;
    public string DescProxPasso { get; set; } = string.Empty;
    public string TempoPermProx { get; set; } = string.Empty;
    public int? Seq { get; set; }

    public Proposicao GenerateProposicaoLog(TipoLogProposicao tipoLogProposicao, User responsavel, string diferenca)
    {
        Logs.Add(new LogProposicao(this, tipoLogProposicao, responsavel, diferenca));
        return this;
    }

    public Proposicao ChangeStatus(ProposicaoStatus newStatus, TipoLogProposicao tipoLogProposicao, User responsavel)
    {
        GenerateProposicaoLog(tipoLogProposicao, responsavel, $@"Mudança de status de {Status} para {newStatus}");
        Status = newStatus;
        return this;
    }

    public Proposicao AddToReuniao(Reuniao reuniao, User responsavel)
    {
        GenerateProposicaoLog(TipoLogProposicao.InclusaoPauta, responsavel,
            $@"Inclusão na pauta da RD número {reuniao.NumeroReuniao}");
        Reuniao = reuniao;
        Status = ProposicaoStatus.InclusaEmReuniao;
        return this;
    }

    public Proposicao RemoveFromReuniao(Reuniao reuniao, User responsavel)
    {
        GenerateProposicaoLog(TipoLogProposicao.RemocaoPauta, responsavel,
            $@"Remoção da pauta da RD número {reuniao.NumeroReuniao}");
        Reuniao = new Reuniao();
        Status = ProposicaoStatus.DisponivelInclusaoPauta;
        return this;
    }

    public Proposicao AddDiretorVote(User diretor, Voto vote, string ajustes)
    {
        GenerateProposicaoLog(LogProposicao.ConvertFromTipoVoto(vote.VotoRd), diretor,
            $@"Voto de Diretor {diretor.Nome} em RD: {vote.VotoRd}");
        AjustesRd += $"\n\n{ajustes}";
        VotosRd.Add(vote);
        return this;
    }

    public bool CheckIfParticipanteVoted(Participante participante)
    {
        return VotosRd.Any(v => v.Participante == participante);
    }

    public Voto GetParticipanteVoto(Participante participante)
    {
        return VotosRd.SingleOrDefault(v => v.Participante == participante) ??
               throw new InvalidOperationException("Não há votos para este participante");
    }

    public Proposicao CalculateNewProposicaoStatusFromVotes()
    {
        if (Reuniao.Participantes.Count > VotosRd.Count)
        {
            // voting hasn't finished, status unchanged
            return this;
        }

        var approvedCount = 0;
        var repprovedCount = 0;
        var suspensionCount = 0;
        var abstentionCount = 0;
        foreach (var reuniaoParticipante in Reuniao.Participantes)
        {
            if (CheckIfParticipanteVoted(reuniaoParticipante))
            {
                var participanteVote = GetParticipanteVoto(reuniaoParticipante);
                switch (participanteVote.VotoRd)
                {
                    case TipoVotoRd.Aprovacao:
                        approvedCount++;
                        break;
                    case TipoVotoRd.Reprovacao:
                        repprovedCount++;
                        break;
                    case TipoVotoRd.Suspensao:
                        suspensionCount++;
                        break;
                    case TipoVotoRd.Abstencao:
                        abstentionCount++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        if (abstentionCount == VotosRd.Count)
        {
            Status = ProposicaoStatus.SuspensaRd;
            return this;
        }

        if (approvedCount > (VotosRd.Count - abstentionCount) / 2)
        {
            Status = ProposicaoStatus.AprovadaRd;
            return this;
        }

        if (repprovedCount > (VotosRd.Count - abstentionCount) / 2)
        {
            Status = ProposicaoStatus.ReprovadaRd;
            return this;
        }

        if (suspensionCount > (VotosRd.Count - abstentionCount) / 2)
        {
            Status = ProposicaoStatus.SuspensaRd;
            return this;
        }

        if (approvedCount >= repprovedCount || approvedCount >= suspensionCount)
        {
            Status = ProposicaoStatus.AprovadaRd;
            return this;
        }

        if (repprovedCount >= suspensionCount)
        {
            Status = ProposicaoStatus.ReprovadaRd;
            return this;
        }

        Status = ProposicaoStatus.SuspensaRd;
        return this;
    }
}