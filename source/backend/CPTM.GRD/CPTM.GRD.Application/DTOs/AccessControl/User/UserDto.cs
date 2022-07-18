using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.AccessControl.User;

public class UserDto : IUserDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string UsernameAd { get; set; } = string.Empty;
    public AccessLevel NivelAcesso { get; set; }
    public ICollection<GroupDto> AreasAcesso { get; set; } = new List<GroupDto>();
    public string Funcao { get; set; } = string.Empty;
}