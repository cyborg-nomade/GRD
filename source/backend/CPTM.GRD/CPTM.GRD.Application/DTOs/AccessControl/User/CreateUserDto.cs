using CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;

namespace CPTM.GRD.Application.DTOs.AccessControl.User;

public class CreateUserDto : IUsernameAdUserDto
{
    public string UsernameAd { get; set; } = string.Empty;
}