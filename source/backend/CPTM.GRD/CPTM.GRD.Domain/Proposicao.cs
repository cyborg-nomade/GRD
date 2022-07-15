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
    public string MotivoRetornoDiretoriaResp { get; set; } = string.Empty;
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

    private Proposicao GenerateProposicaoLog(TipoLogProposicao tipoLogProposicao, User responsavel, string diferenca)
    {
        Logs.Add(new LogProposicao(this, tipoLogProposicao, responsavel, diferenca));
        return this;
    }

    private Proposicao ChangeStatus(ProposicaoStatus newStatus, TipoLogProposicao tipoLogProposicao, User responsavel)
    {
        GenerateProposicaoLog(tipoLogProposicao, responsavel, $@"Mudança de status de {Status} para {newStatus}");
        Status = newStatus;
        return this;
    }

    public Proposicao OnSaveProposicao()
    {
        GenerateProposicaoLog(TipoLogProposicao.Criacao, Criador, "Salvamento inicial");
        return this;
    }

    public Proposicao OnUpdate(User responsavel, string diferenca)
    {
        GenerateProposicaoLog(TipoLogProposicao.Edicao, responsavel, diferenca);
        return this;
    }

    public Proposicao SendToDiretoriaResponsavelApproval(User responsavel)
    {
        ChangeStatus(ProposicaoStatus.EmAprovacaoDiretoriaResp, TipoLogProposicao.EnvioAprovacaoDiretoria, responsavel);
        MotivoRetornoDiretoriaResp = string.Empty;
        MotivoRetornoGrg = string.Empty;
        return this;
    }

    public Proposicao DiretoriaResponsavelApproveProposicao(User responsavel)
    {
        ChangeStatus(ProposicaoStatus.DisponivelInclusaoPauta, TipoLogProposicao.AprovacaoDiretoria, responsavel);
        MotivoRetornoDiretoriaResp = string.Empty;
        MotivoRetornoGrg = string.Empty;
        return this;
    }

    public Proposicao DiretoriaResponsavelRepproveProposicao(User responsavel, string motivoRetorno)
    {
        ChangeStatus(ProposicaoStatus.ReprovadoDiretoriaResp, TipoLogProposicao.ReprovacaoDiretoria, responsavel);
        MotivoRetornoDiretoriaResp = motivoRetorno;
        return this;
    }

    public Proposicao GrgReturnProposicaoToDiretoria(User responsavel, string motivoRetorno)
    {
        ChangeStatus(ProposicaoStatus.EmAprovacaoDiretoriaResp, TipoLogProposicao.GrgRetornaParaDiretoria, responsavel);
        MotivoRetornoGrg = motivoRetorno;
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
        ChangeStatus(ProposicaoStatus.DisponivelInclusaoPauta, TipoLogProposicao.RemocaoPauta, responsavel);
        return this;
    }

    public Proposicao AnnotateProposicaoInPrevia(User responsavel, string anotacao)
    {
        AnotacoesPrevia = anotacao;
        return this;
    }

    public Proposicao AddToPautaDefinitiva(User responsavel)
    {
        ChangeStatus(ProposicaoStatus.EmPautaDefinitiva, TipoLogProposicao.Edicao, responsavel);
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

    private bool CheckIfParticipanteVoted(Participante participante)
    {
        return VotosRd.Any(v => v.Participante == participante);
    }

    private Voto GetParticipanteVoto(Participante participante)
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

    public Proposicao OnReuniaoRealizada(Reuniao reuniao, User responsavel)
    {
        if (AjustesRd != string.Empty)
        {
            if (Status == ProposicaoStatus.AprovadaRd)
            {
                ChangeStatus(ProposicaoStatus.AprovadaRdAguardandoAjustes,
                    TipoLogProposicao.SolicitaAjustesRd, responsavel);
            }

            if (Status == ProposicaoStatus.SuspensaRd)
            {
                ChangeStatus(ProposicaoStatus.SuspensaRdAguardandoAjustes,
                    TipoLogProposicao.SolicitaAjustesRd, responsavel);
            }
        }
        else if (Status == ProposicaoStatus.SuspensaRd)
        {
            RemoveFromReuniao(reuniao, responsavel);
            reuniao.RemoveProposicao(this, responsavel);
        }

        return this;
    }

    public Proposicao OnEmitResolucaoDiretoria(User responsavel, string resolucaoDiretoriaFilePath)
    {
        if (Status is ProposicaoStatus.AprovadaRd or ProposicaoStatus.ReprovadaRd or ProposicaoStatus.SuspensaRd)
        {
            GenerateProposicaoLog(TipoLogProposicao.EmissaoResolucaoDiretoria, responsavel,
                "Emissão Resolução Diretoria");
            ResolucaoDiretoriaFilePath = resolucaoDiretoriaFilePath;
        }
        else
        {
            throw new Exception("Proposição em status incorreto");
        }

        return this;
    }

    public Proposicao DiretoriaReturnProposicaoToGrgAfterAjustesRd(User responsavel)
    {
        switch (Status)
        {
            case ProposicaoStatus.AprovadaRdAguardandoAjustes:
                ChangeStatus(ProposicaoStatus.AprovadaRdAjustesRealizados, TipoLogProposicao.EnvioAjustesRd,
                    responsavel);
                break;
            case ProposicaoStatus.SuspensaRdAguardandoAjustes:
                ChangeStatus(ProposicaoStatus.SuspensaRdAjustesRealizados, TipoLogProposicao.EnvioAjustesRd,
                    responsavel);
                break;
            case ProposicaoStatus.EmPreenchimento:
            case ProposicaoStatus.EmAprovacaoDiretoriaResp:
            case ProposicaoStatus.ReprovadoDiretoriaResp:
            case ProposicaoStatus.DisponivelInclusaoPauta:
            case ProposicaoStatus.RetornadoGrg:
            case ProposicaoStatus.InclusaEmReuniao:
            case ProposicaoStatus.EmPautaPrevia:
            case ProposicaoStatus.EmPautaDefinitiva:
            case ProposicaoStatus.AprovadaRd:
            case ProposicaoStatus.ReprovadaRd:
            case ProposicaoStatus.SuspensaRd:
            case ProposicaoStatus.AprovadaRdAjustesRealizados:
            case ProposicaoStatus.SuspensaRdAjustesRealizados:
            default:
                throw new ArgumentOutOfRangeException();
        }

        return this;
    }

    public Proposicao GrgApproveProposicaoAjustesRd(User responsavel)
    {
        AjustesRd = string.Empty;
        switch (Status)
        {
            case ProposicaoStatus.AprovadaRdAjustesRealizados:
                ChangeStatus(ProposicaoStatus.AprovadaRd, TipoLogProposicao.AjustesRdok, responsavel);
                break;
            case ProposicaoStatus.SuspensaRdAjustesRealizados:
                ChangeStatus(ProposicaoStatus.DisponivelInclusaoPauta, TipoLogProposicao.AjustesRdok, responsavel);
                if (Reuniao.NumeroReuniao != 0) RemoveFromReuniao(Reuniao, responsavel);
                break;
            case ProposicaoStatus.EmPreenchimento:
            case ProposicaoStatus.EmAprovacaoDiretoriaResp:
            case ProposicaoStatus.ReprovadoDiretoriaResp:
            case ProposicaoStatus.DisponivelInclusaoPauta:
            case ProposicaoStatus.RetornadoGrg:
            case ProposicaoStatus.InclusaEmReuniao:
            case ProposicaoStatus.EmPautaPrevia:
            case ProposicaoStatus.EmPautaDefinitiva:
            case ProposicaoStatus.AprovadaRd:
            case ProposicaoStatus.ReprovadaRd:
            case ProposicaoStatus.SuspensaRd:
            case ProposicaoStatus.AprovadaRdAguardandoAjustes:
            case ProposicaoStatus.SuspensaRdAguardandoAjustes:
            default:
                throw new ArgumentOutOfRangeException();
        }

        return this;
    }

    public Proposicao Archive(User responsavel)
    {
        GenerateProposicaoLog(TipoLogProposicao.Arquivamento, responsavel, "Arquivamento");
        Arquivada = true;
        return this;
    }
}