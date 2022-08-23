using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.AccessControl.User;

public class UpdateUserDto : IBaseUserDto, IFullUserDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public AccessLevel NivelAcesso { get; set; }
    public ICollection<GroupDto> AreasAcesso { get; set; } = new List<GroupDto>();
    public string Funcao { get; set; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}