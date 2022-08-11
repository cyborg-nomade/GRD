using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;

public interface IParticipanteReuniaoDto
{
    public ICollection<ParticipanteDto> Participantes { get; set; }
    public ICollection<ParticipanteDto> ParticipantesPrevia { get; set; }
}