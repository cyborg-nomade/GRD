using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

public class CreateParticipanteDto : IParticipanteDto
{
    public UserDto User { get; set; } = new UserDto();
    public string DiretoriaArea { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}