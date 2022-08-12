using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Logging;
using CPTM.GRD.Domain.Proposicoes;

namespace CPTM.GRD.Domain.Reunioes;

public class Reuniao
{
    public int Id { get; set; }
    public int NumeroReuniao { get; set; }
    public DateTime Data { get; set; }
    public DateTime Horario { get; set; }
    public ReuniaoStatus Status { get; set; }
    public DateTime DataPrevia { get; set; }
    public DateTime HorarioPrevia { get; set; }
    public string Local { get; set; } = string.Empty;
    public TipoReuniao TipoReuniao { get; set; }
    public ICollection<Proposicao>? Proposicoes { get; set; } = new List<Proposicao>();
    public ICollection<Proposicao>? ProposicoesPrevia { get; set; } = new List<Proposicao>();
    public ICollection<User>? Participantes { get; set; } = new List<User>();
    public ICollection<User>? ParticipantesPrevia { get; set; } = new List<User>();
    public ICollection<Acao>? Acoes { get; set; } = new List<Acao>();
    public string? Comunicado { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? MensagemEMail { get; set; }
    public ICollection<LogReuniao> Logs { get; set; } = new List<LogReuniao>();
    public string? PautaPreviaFilePath { get; set; } = string.Empty;
    public string? MemoriaPreviaFilePath { get; set; } = string.Empty;
    public string? PautaDefinitivaFilePath { get; set; } = string.Empty;
    public string? RelatorioDeliberativoFilePath { get; set; } = string.Empty;
    public string? AtaFilePath { get; set; } = string.Empty;

    private Reuniao GenerateReuniaoLog(TipoLogReuniao tipoLogReuniao, User responsavel, string diferenca)
    {
        Logs.Add(new LogReuniao(this, tipoLogReuniao, responsavel, diferenca));
        return this;
    }

    private Reuniao ChangeStatus(ReuniaoStatus newStatus, TipoLogReuniao tipoLogReuniao, User responsavel)
    {
        GenerateReuniaoLog(tipoLogReuniao, responsavel, $@"Mudança de status de {Status} para {newStatus}");
        Status = newStatus;
        return this;
    }

    public Reuniao OnSave(int numeroReuniao, User responsavel, List<User> participantesPrevia, List<User> participantes)
    {
        NumeroReuniao = numeroReuniao;
        ParticipantesPrevia = participantesPrevia;
        Participantes = participantes;
        ChangeStatus(ReuniaoStatus.Registrada, TipoLogReuniao.Criacao, responsavel);
        return this;
    }

    public Reuniao OnUpdate(User responsavel, string diferenca)
    {
        GenerateReuniaoLog(TipoLogReuniao.Edicao, responsavel, diferenca);
        return this;
    }

    public Reuniao CreateAcao(Acao acao, User responsavel)
    {
        if (Status < ReuniaoStatus.Pauta)
        {
            throw new Exception("Não é possível criar uma ação em uma reunião que não está em pauta");
        }

        acao.AddToReuniao(this, responsavel);
        Acoes?.Add(acao);
        return this;
    }

    internal Reuniao FollowUpAcao(Acao acao)
    {
        Acoes?.Add(acao);
        return this;
    }

    public Reuniao RemoveAcao(Acao acao, User responsavel)
    {
        if (Acoes == null)
            throw new Exception("Não existem ações nesta reunião");

        if (!Acoes.Remove(acao))
            throw new Exception("Esta ação não está inclusa nesta reunião");

        acao.RemoveFromReuniao(this, responsavel);
        return this;
    }

    public Reuniao AddProposicao(Proposicao proposicao, User responsavel)
    {
        Proposicoes?.Add(proposicao);
        proposicao.AddToReuniao(this, responsavel);
        GenerateReuniaoLog(TipoLogReuniao.InclusaoProposicao, responsavel,
            $@"Inclusão da Proposição IDPRD: {proposicao.IdPrd}");
        return this;
    }

    public Reuniao RemoveProposicao(Proposicao proposicao, User responsavel)
    {
        if (Proposicoes == null)
        {
            throw new Exception("Não existem proposições nesta reunião");
        }

        if (!Proposicoes.Remove(proposicao))
        {
            throw new Exception("Esta proposição não existe nesta reunião");
        }

        proposicao.RemoveFromReuniao(this, responsavel);
        GenerateReuniaoLog(TipoLogReuniao.RemocaoProposicao, responsavel,
            $@"Remoção da Proposição IDPRD: {proposicao.IdPrd}");
        return this;
    }

    public Reuniao OnEmitPautaPrevia(User responsavel, string pautaPreviaFilePath)
    {
        if (Status != ReuniaoStatus.Registrada)
        {
            throw new Exception("Não é possível emitir a Pauta Prévia. Reunião em status incorreto.");
        }

        ProposicoesPrevia = Proposicoes;
        PautaPreviaFilePath = pautaPreviaFilePath;
        ChangeStatus(ReuniaoStatus.Previa, TipoLogReuniao.EmissaoPautaPrevia, responsavel);
        return this;
    }

    public Reuniao OnEmitMemoriaPrevia(User responsavel, string memoriaPreviaFilePath)
    {
        if (Status != ReuniaoStatus.Previa)
        {
            throw new Exception("Não é possível emitir a Memória da Prévia. Reunião em status incorreto.");
        }

        MemoriaPreviaFilePath = memoriaPreviaFilePath;
        GenerateReuniaoLog(TipoLogReuniao.EmissaoMemoriaPrevia, responsavel, "Emissão Memória Prévia");
        return this;
    }

    public Reuniao OnEmitPautaDefinitiva(User responsavel, string pautaDefinitivaFilePath)
    {
        if (Status != ReuniaoStatus.Previa)
        {
            throw new Exception("Não é possível emitir a Pauta Definitiva. Reunião em status incorreto.");
        }

        PautaDefinitivaFilePath = pautaDefinitivaFilePath;
        ChangeStatus(ReuniaoStatus.Pauta, TipoLogReuniao.EmissaoPautaDefinitiva, responsavel);

        if (Proposicoes == null) return this;
        foreach (var proposicao in Proposicoes)
        {
            proposicao.AddToPautaDefinitiva(responsavel);
        }

        return this;
    }

    public Reuniao OnEmitRelatorioDeliberativo(User responsavel, string relatorioDefinitivoFilePath)
    {
        if (Status != ReuniaoStatus.Pauta)
        {
            throw new Exception("Não é possível emitir o Relatório Deliberativo. Reunião em status incorreto.");
        }

        RelatorioDeliberativoFilePath = relatorioDefinitivoFilePath;
        ChangeStatus(ReuniaoStatus.Realizada, TipoLogReuniao.RealizacaoRd, responsavel);
        GenerateReuniaoLog(TipoLogReuniao.EmissaoRelatorioDeliberativo, responsavel, "Emissão Relatório Deliberativo");

        if (Proposicoes == null) return this;
        foreach (var proposicao in Proposicoes.ToList())
        {
            proposicao.OnReuniaoRealizada(this, responsavel);
        }

        return this;
    }

    public Proposicao OnEmitProposicaoResolucaoDiretoria(int pid, User responsavel, string resolucaoDiretoriaFilePath)
    {
        if (Status != ReuniaoStatus.Pauta)
        {
            throw new Exception("Não é possível emitir o Resolução de Diretoria. Reunião em status incorreto.");
        }

        if (Proposicoes == null)
        {
            throw new Exception("Não há proposições nesta Reunião");
        }

        var proposicao = Proposicoes.SingleOrDefault(p => p.Id == pid);

        if (proposicao == null) throw new Exception("Essa Proposição não existe na Reunião indicada");

        proposicao.OnEmitResolucaoDiretoria(responsavel, resolucaoDiretoriaFilePath);

        return proposicao;
    }

    public Reuniao OnEmitAta(User responsavel, string ataFilePath)
    {
        AtaFilePath = ataFilePath;
        Archive(responsavel);
        return this;
    }

    private Reuniao Archive(User responsavel)
    {
        if (Status != ReuniaoStatus.Realizada)
        {
            throw new Exception("Não é possível arquivar uma reunição que não foi realizada");
        }

        ChangeStatus(ReuniaoStatus.Arquivada, TipoLogReuniao.Arquivamento, responsavel);
        if (Proposicoes == null) return this;
        foreach (var proposicao in Proposicoes)
        {
            proposicao.Archive(responsavel);
        }

        return this;
    }
}