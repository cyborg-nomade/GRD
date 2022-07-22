using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;

public interface IBaseReuniaoDto
{
    public DateOnly Data { get; set; }
    public TimeOnly Horario { get; set; }
    public DateOnly DataPrevia { get; set; }
    public TimeOnly HorarioPrevia { get; set; }
    public string Local { get; set; }
    public TipoReuniao TipoReuniao { get; set; }
    public ICollection<ProposicaoDto> Proposicoes { get; set; }
    public ICollection<ProposicaoDto> ProposicoesPrevia { get; set; }
    public ICollection<IBaseParticipanteDto> Participantes { get; set; }
    public ICollection<IBaseParticipanteDto> ParticipantesPrevia { get; set; }
    public ICollection<IBaseAcaoDto> Acoes { get; set; }
    public string? Comunicado { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? MensagemEMail { get; set; }
}