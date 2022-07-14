using CPTM.GRD.Common;
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

    public Reuniao AddAcao(Acao acao)
    {
        acao.GenerateLogAcao(TipoLogAcao.Criacao, "Salvamento inicial");
        Acoes.Add(acao);
        return this;
    }
}