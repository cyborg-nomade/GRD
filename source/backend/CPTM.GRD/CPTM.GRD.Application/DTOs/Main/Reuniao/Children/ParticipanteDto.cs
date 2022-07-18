using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

public class ParticipanteDto : IParticipanteDto
{
    public int Id { get; set; }
    public UserDto User { get; set; } = new UserDto();
    public GroupDto DiretoriaArea { get; set; } = new GroupDto();
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}