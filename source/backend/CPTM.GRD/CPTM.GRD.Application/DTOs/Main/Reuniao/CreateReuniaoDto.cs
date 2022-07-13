using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao;

public class CreateReuniaoDto
{
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
}