using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.Responses;

public class AuthResponse
{
    public UserDto User { get; init; } = new UserDto();
    public string Token { get; init; } = string.Empty;
    public DateTime ExpirationDate { get; init; }
}