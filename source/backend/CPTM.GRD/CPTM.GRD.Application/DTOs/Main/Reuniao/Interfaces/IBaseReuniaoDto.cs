using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;

public interface IBaseReuniaoDto
{
    public DateTime Data { get; set; }
    public DateTime Horario { get; set; }
    public DateTime DataPrevia { get; set; }
    public DateTime HorarioPrevia { get; set; }
    public string Local { get; set; }
    public TipoReuniao TipoReuniao { get; set; }
    public ICollection<ProposicaoDto> Proposicoes { get; set; }
    public ICollection<ProposicaoDto> ProposicoesPrevia { get; set; }
    public ICollection<CreateParticipanteDto> Participantes { get; set; }
    public ICollection<CreateParticipanteDto> ParticipantesPrevia { get; set; }
    public ICollection<AcaoDto> Acoes { get; set; }
    public string? Comunicado { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? MensagemEMail { get; set; }
}