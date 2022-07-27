using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao;

public class CreateReuniaoDto : IBaseReuniaoDto
{
    public DateTime Data { get; set; }
    public DateTime Horario { get; set; }
    public DateTime DataPrevia { get; set; }
    public DateTime HorarioPrevia { get; set; }
    public string Local { get; set; } = string.Empty;
    public TipoReuniao TipoReuniao { get; set; }
    public ICollection<ProposicaoDto> Proposicoes { get; set; } = new List<ProposicaoDto>();
    public ICollection<ProposicaoDto> ProposicoesPrevia { get; set; } = new List<ProposicaoDto>();
    public ICollection<IBaseParticipanteDto> Participantes { get; set; } = new List<IBaseParticipanteDto>();
    public ICollection<IBaseParticipanteDto> ParticipantesPrevia { get; set; } = new List<IBaseParticipanteDto>();
    public ICollection<IBaseAcaoDto> Acoes { get; set; } = new List<IBaseAcaoDto>();
    public string? Comunicado { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? MensagemEMail { get; set; }
}