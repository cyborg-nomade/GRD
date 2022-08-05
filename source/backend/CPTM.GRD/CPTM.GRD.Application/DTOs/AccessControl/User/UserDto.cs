using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.AccessControl.User;

public class UserDto : IBaseUserDto, IFullUserDto, IUsernameAdUserDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string UsernameAd { get; set; } = string.Empty;
    public AccessLevel NivelAcesso { get; set; }
    public ICollection<GroupDto> AreasAcesso { get; set; } = new List<GroupDto>();
    public string Funcao { get; set; } = string.Empty;

    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id},\n{nameof(Nome)}: {Nome},\n{nameof(UsernameAd)}: {UsernameAd},\n{nameof(NivelAcesso)}: {NivelAcesso},\n{nameof(AreasAcesso)}: [\n{string.Join(",", AreasAcesso)}\n],\n{nameof(Funcao)}: {Funcao}";
    }
}