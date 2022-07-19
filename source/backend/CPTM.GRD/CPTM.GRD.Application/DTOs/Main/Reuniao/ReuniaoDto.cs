using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Interfaces;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao;

public class ReuniaoDto : IBaseReuniaoDto, IFullReuniaoDto, IAutoPropertiesReuniaoDto
{
    public DateOnly Data { get; set; }
    public TimeOnly Horario { get; set; }
    public DateOnly DataPrevia { get; set; }
    public TimeOnly HorarioPrevia { get; set; }
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
    public int Id { get; set; }
    public int NumeroReuniao { get; set; }
    public ReuniaoStatus Status { get; set; }
    public string PautaPreviaFilePath { get; set; } = string.Empty;
    public string MemoriaPreviaFilePath { get; set; } = string.Empty;
    public string PautaDefinitivaFilePath { get; set; } = string.Empty;
    public string RelatorioDeliberativoFilePath { get; set; } = string.Empty;
    public string AtaFilePath { get; set; } = string.Empty;
}