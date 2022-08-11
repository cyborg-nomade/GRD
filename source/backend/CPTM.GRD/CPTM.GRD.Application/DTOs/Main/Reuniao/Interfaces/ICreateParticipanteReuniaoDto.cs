using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Interfaces;

public interface ICreateParticipanteReuniaoDto
{
    public ICollection<UserDto> Participantes { get; set; }
    public ICollection<UserDto> ParticipantesPrevia { get; set; }
}