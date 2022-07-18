using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Logging;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes.Children;

namespace CPTM.GRD.Domain.Reunioes;

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

    private Reuniao GenerateReuniaoLog(TipoLogReuniao tipoLogReuniao, User responsavel, string diferenca)
    {
        Logs.Add(new LogReuniao(this, tipoLogReuniao, responsavel, diferenca));
        return this;
    }

    public Reuniao OnSave(User responsavel)
    {
        GenerateReuniaoLog(TipoLogReuniao.Criacao, responsavel, "Salvamento inicial");
        return this;
    }

    public Reuniao OnUpdate(User responsavel, string diferenca)
    {
        GenerateReuniaoLog(TipoLogReuniao.Edicao, responsavel, diferenca);
        return this;
    }

    public Reuniao CreateAcao(Acao acao, User responsavel)
    {
        acao.AddToReuniao(this, responsavel);
        Acoes.Add(acao);
        return this;
    }

    internal Reuniao FollowUpAcao(Acao acao)
    {
        Acoes.Add(acao);
        return this;
    }

    public Reuniao RemoveAcao(Acao acao, User responsavel)
    {
        acao.RemoveFromReuniao(this, responsavel);
        Acoes.Remove(acao);
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

    private Reuniao ChangeStatus(ReuniaoStatus newStatus, TipoLogReuniao tipoLogReuniao, User responsavel)
    {
        GenerateReuniaoLog(tipoLogReuniao, responsavel, $@"Mudança de status de {Status} para {newStatus}");
        Status = newStatus;
        return this;
    }

    public Reuniao OnEmitPautaPrevia(User responsavel, string pautaPreviaFilePath)
    {
        GenerateReuniaoLog(TipoLogReuniao.EmissaoPautaPrevia, responsavel, "Emissão Pauta Prévia");
        ProposicoesPrevia = Proposicoes;
        PautaPreviaFilePath = pautaPreviaFilePath;
        return this;
    }

    public Reuniao OnEmitMemoriaPrevia(User responsavel, string memoriaPreviaFilePath)
    {
        GenerateReuniaoLog(TipoLogReuniao.EmissaoMemoriaPrevia, responsavel, "Emissão Memória Prévia");
        MemoriaPreviaFilePath = memoriaPreviaFilePath;
        return this;
    }

    public Reuniao OnEmitPautaDefinitiva(User responsavel, string pautaDefinitivaFilePath)
    {
        GenerateReuniaoLog(TipoLogReuniao.EmissaoPautaDefinitiva, responsavel, "Emissão Pauta Definitiva");
        PautaDefinitivaFilePath = pautaDefinitivaFilePath;
        foreach (var proposicao in Proposicoes)
        {
            proposicao.AddToPautaDefinitiva(responsavel);
        }

        return this;
    }

    public Reuniao OnEmitRelatorioDeliberativo(User responsavel, string relatorioDefinitivoFilePath)
    {
        GenerateReuniaoLog(TipoLogReuniao.EmissaoRelatorioDeliberativo, responsavel, "Emissão Relatório Deliberativo");
        ChangeStatus(ReuniaoStatus.Realizada, TipoLogReuniao.RealizacaoRd, responsavel);
        RelatorioDeliberativoFilePath = relatorioDefinitivoFilePath;
        foreach (var proposicao in Proposicoes.ToList())
        {
            proposicao.OnReuniaoRealizada(this, responsavel);
        }

        return this;
    }

    public Proposicao OnEmitProposicaoResolucaoDiretoria(int pid, User responsavel, string resolucaoDiretoriaFilePath)
    {
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
        ChangeStatus(ReuniaoStatus.Arquivada, TipoLogReuniao.Arquivamento, responsavel);
        foreach (var proposicao in Proposicoes)
        {
            proposicao.Archive(responsavel);
        }

        return this;
    }
}