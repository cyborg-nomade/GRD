using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao;

public class ReuniaoDto : IBaseReuniaoDto, IFullReuniaoDto, IAutoPropertiesReuniaoDto
{
    public DateTime Data { get; set; }
    public DateTime Horario { get; set; }
    public DateTime DataPrevia { get; set; }
    public DateTime HorarioPrevia { get; set; }
    public string Local { get; set; } = string.Empty;
    public TipoReuniao TipoReuniao { get; set; }
    public ICollection<ProposicaoDto> Proposicoes { get; set; } = new List<ProposicaoDto>();
    public ICollection<ProposicaoDto> ProposicoesPrevia { get; set; } = new List<ProposicaoDto>();
    public ICollection<UserDto> Participantes { get; set; } = new List<UserDto>();
    public ICollection<UserDto> ParticipantesPrevia { get; set; } = new List<UserDto>();
    public ICollection<AcaoDto> Acoes { get; set; } = new List<AcaoDto>();
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

    public override string ToString()
    {
        return @$"{nameof(Data)}: {Data}, 
{nameof(Horario)}: {Horario}, 
{nameof(DataPrevia)}: {DataPrevia}, 
{nameof(HorarioPrevia)}: {HorarioPrevia}, 
{nameof(Local)}: {Local}, 
{nameof(TipoReuniao)}: {TipoReuniao}, 
{nameof(Proposicoes)}: {Proposicoes}, 
{nameof(ProposicoesPrevia)}: {ProposicoesPrevia}, 
{nameof(Participantes)}: {Participantes}, 
{nameof(ParticipantesPrevia)}: {ParticipantesPrevia}, 
{nameof(Acoes)}: {Acoes}, 
{nameof(Comunicado)}: {Comunicado}, 
{nameof(OutrasObservacoes)}: {OutrasObservacoes}, 
{nameof(MensagemEMail)}: {MensagemEMail}, 
{nameof(Id)}: {Id}, 
{nameof(NumeroReuniao)}: {NumeroReuniao}, 
{nameof(Status)}: {Status}, 
{nameof(PautaPreviaFilePath)}: {PautaPreviaFilePath}, 
{nameof(MemoriaPreviaFilePath)}: {MemoriaPreviaFilePath}, 
{nameof(PautaDefinitivaFilePath)}: {PautaDefinitivaFilePath}, 
{nameof(RelatorioDeliberativoFilePath)}: {RelatorioDeliberativoFilePath}, 
{nameof(AtaFilePath)}: {AtaFilePath}";
    }
}