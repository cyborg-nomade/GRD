using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.AccessControl.User;

public class UserDto : CreateUserDto, IUserDto
{
    public int Id { get; set; }
}