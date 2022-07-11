using CPTM.GRD.Application.DTOs.Logging;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs;

public class ReuniaoDto
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
    public ICollection<ProposicaoDto> Proposicoes { get; set; } = new List<ProposicaoDto>();
    public ICollection<ProposicaoDto> ProposicoesPrevia { get; set; } = new List<ProposicaoDto>();
    public ICollection<ParticipanteDto> Participantes { get; set; } = new List<ParticipanteDto>();
    public ICollection<ParticipanteDto> ParticipantesPrevia { get; set; } = new List<ParticipanteDto>();
    public ICollection<AcaoDto> Acoes { get; set; } = new List<AcaoDto>();
    public string? Comunicado { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? MensagemEMail { get; set; }
    public ICollection<LogReuniaoDto> Logs { get; set; } = new List<LogReuniaoDto>();
}