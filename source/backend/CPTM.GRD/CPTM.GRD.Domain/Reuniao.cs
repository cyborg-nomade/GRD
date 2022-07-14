using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Logging;

namespace CPTM.GRD.Domain;

public class Reuniao
{
    public int Id { get; set; }
    public int NumeroReuniao { get; set; }
    public DateOnly Data { get; set; }
    public TimeOnly Horario { get; set; }
    public ReuniaoStatus Status { get; set; }
    public DateOnly DataPrevia { get; set; }
    public TimeOnly HorarioPrevia { get; set; }
    public string Local { get; set; } = string.Empty;
    public TipoReuniao TipoReuniao { get; set; }
    public ICollection<Proposicao> Proposicoes { get; set; } = new List<Proposicao>();
    public ICollection<Proposicao> ProposicoesPrevia { get; set; } = new List<Proposicao>();
    public ICollection<Participante> Participantes { get; set; } = new List<Participante>();
    public ICollection<Participante> ParticipantesPrevia { get; set; } = new List<Participante>();
    public ICollection<Acao> Acoes { get; set; } = new List<Acao>();
    public string? Comunicado { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? MensagemEMail { get; set; }
    public ICollection<LogReuniao> Logs { get; set; } = new List<LogReuniao>();
    public string PautaPreviaFilePath { get; set; } = string.Empty;
    public string MemoriaPreviaFilePath { get; set; } = string.Empty;
    public string PautaDefinitivaFilePath { get; set; } = string.Empty;
    public string RelatorioDeliberativoFilePath { get; set; } = string.Empty;
    public string AtaFilePath { get; set; } = string.Empty;

    public Reuniao GenerateReuniaoLog(TipoLogReuniao tipoLogReuniao, User responsavel, string diferenca)
    {
        var newLog = new LogReuniao()
        {
            Data = DateTime.Now,
            Tipo = tipoLogReuniao,
            ReuniaoId = $@"Número Reunião: {NumeroReuniao}",
            Diferenca = diferenca,
            UsuarioResp = responsavel,
        };
        Logs.Add(newLog);
        return this;
    }

    public Reuniao AddAcao(Acao acao)
    {
        acao.GenerateLogAcao(TipoLogAcao.Criacao, "Salvamento inicial");
        Acoes.Add(acao);
        return this;
    }

    public Reuniao AddProposicao(Proposicao proposicao, User responsavel)
    {
        GenerateReuniaoLog(TipoLogReuniao.InclusaoProposicao, responsavel,
            $@"Inclusão da Proposição IDPRD: {proposicao.IdPrd}");
        proposicao.AddToReuniao(this, responsavel);
        Proposicoes.Add(proposicao);
        return this;
    }

    public Reuniao RemoveProposicao(Proposicao proposicao, User responsavel)
    {
        GenerateReuniaoLog(TipoLogReuniao.RemocaoProposicao, responsavel,
            $@"Remoção da Proposição IDPRD: {proposicao.IdPrd}");
        proposicao.RemoveFromReuniao(this, responsavel);
        Proposicoes.Remove(proposicao);
        return this;
    }

    public Reuniao ChangeStatus(ReuniaoStatus newStatus, TipoLogReuniao tipoLogReuniao, User responsavel)
    {
        GenerateReuniaoLog(tipoLogReuniao, responsavel, $@"Mudança de status de {Status} para {newStatus}");
        Status = newStatus;
        return this;
    }

    public Reuniao PautaPrevia(User responsavel)
    {
        GenerateReuniaoLog(TipoLogReuniao.EmissaoPautaPrevia, responsavel, "Emissão Pauta Prévia");
        ProposicoesPrevia = Proposicoes;
        return this;
    }

    public Reuniao PautaDefinitiva(User responsavel)
    {
        GenerateReuniaoLog(TipoLogReuniao.EmissaoPautaDefinitiva, responsavel, "Emissão Pauta Definitiva");
        foreach (var proposicao in Proposicoes)
        {
            proposicao.ChangeStatus(ProposicaoStatus.EmPautaDefinitiva, TipoLogProposicao.Edicao, responsavel);
        }

        return this;
    }

    public Reuniao RelatorioDeliberativo(User responsavel)
    {
        GenerateReuniaoLog(TipoLogReuniao.EmissaoRelatorioDeliberativo, responsavel, "Emissão Relatório Deliberativo");
        ChangeStatus(ReuniaoStatus.Realizada, TipoLogReuniao.RealizacaoRd, responsavel);

        foreach (var proposicao in Proposicoes.ToList())
        {
            if (proposicao.AjustesRd != string.Empty)
            {
                if (proposicao.Status == ProposicaoStatus.AprovadaRd)
                {
                    proposicao.ChangeStatus(ProposicaoStatus.AprovadaRdAguardandoAjustes,
                        TipoLogProposicao.EnvioAjustesRd, responsavel);
                }

                if (proposicao.Status == ProposicaoStatus.SuspensaRd)
                {
                    proposicao.ChangeStatus(ProposicaoStatus.SuspensaRdAguardandoAjustes,
                        TipoLogProposicao.EnvioAjustesRd, responsavel);
                }
            }
            else if (proposicao.Status == ProposicaoStatus.SuspensaRd)
            {
                RemoveProposicao(proposicao, responsavel);
            }
        }

        return this;
    }

    public Proposicao ResolucaoDiretoria(int pid, User responsavel)
    {
        var proposicao = Proposicoes.SingleOrDefault(p => p.Id == pid);

        if (proposicao == null) throw new Exception("Essa Proposição não existe na Reunião indicada");

        proposicao.GenerateProposicaoLog(TipoLogProposicao.EmissaoResolucaoDiretoria, responsavel,
            "Emissão Resolução Diretoria");

        return proposicao;
    }

    public Reuniao Archive(TipoLogReuniao tipoLogReuniao, User responsavel)
    {
        ChangeStatus(ReuniaoStatus.Arquivada, tipoLogReuniao, responsavel);
        foreach (var proposicao in Proposicoes)
        {
            proposicao.GenerateProposicaoLog(TipoLogProposicao.Arquivamento, responsavel, "Proposição Arquivada");
            proposicao.Arquivada = true;
        }

        return this;
    }
}