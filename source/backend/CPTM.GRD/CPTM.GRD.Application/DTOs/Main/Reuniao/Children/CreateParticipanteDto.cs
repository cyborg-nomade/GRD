using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Interfaces;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

public class CreateParticipanteDto : IBaseParticipanteDto
{
    public UserDto? User { get; set; } = new UserDto();
    public GroupDto Area { get; set; } = new GroupDto();
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}