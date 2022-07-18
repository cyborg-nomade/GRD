using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao;

public interface IReuniaoDto
{
    public DateOnly Data { get; set; }
    public TimeOnly Horario { get; set; }
    public DateOnly DataPrevia { get; set; }
    public TimeOnly HorarioPrevia { get; set; }
    public string Local { get; set; }
    public TipoReuniao TipoReuniao { get; set; }
    public ICollection<ProposicaoDto> Proposicoes { get; set; }
    public ICollection<ProposicaoDto> ProposicoesPrevia { get; set; }
    public ICollection<ParticipanteDto> Participantes { get; set; }
    public ICollection<ParticipanteDto> ParticipantesPrevia { get; set; }
    public ICollection<AcaoDto> Acoes { get; set; }
    public string? Comunicado { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? MensagemEMail { get; set; }
}