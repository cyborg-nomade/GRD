using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.Responses;

public class AuthResponse
{
    public UserDto User { get; set; } = new UserDto();
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}