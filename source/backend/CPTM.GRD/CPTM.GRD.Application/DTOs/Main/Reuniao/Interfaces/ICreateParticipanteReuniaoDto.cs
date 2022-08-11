using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;

public interface ICreateParticipanteReuniaoDto
{
    public ICollection<CreateParticipanteDto> Participantes { get; set; }
    public ICollection<CreateParticipanteDto> ParticipantesPrevia { get; set; }
}