using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children.Interfaces;

namespace CPTM.GRD.Application.DTOs.Main.Reuniao.Children;

public class ParticipanteDto : IBaseParticipanteDto, IFullParticipanteDto
{
    public int Id { get; set; }
    public UserDto User { get; set; } = new UserDto();
    public GroupDto DiretoriaArea { get; set; } = new GroupDto();
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public override string ToString()
    {
        return @$"{nameof(Id)}: {Id}, 
{nameof(User)}: {User}, 
{nameof(DiretoriaArea)}: {DiretoriaArea}, 
{nameof(Nome)}: {Nome}, 
{nameof(Email)}: {Email}";
    }
}