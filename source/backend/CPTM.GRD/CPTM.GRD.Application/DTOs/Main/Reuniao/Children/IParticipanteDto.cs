using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

public interface IParticipanteDto
{
    public UserDto User { get; set; }
    public string DiretoriaArea { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}