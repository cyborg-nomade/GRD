using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;

public interface IBaseUserDto
{
    public string Nome { get; set; }
    public AccessLevel NivelAcesso { get; set; }
    public ICollection<GroupDto> AreasAcesso { get; set; }
    public string Funcao { get; set; }
    public string Email { get; init; }
}