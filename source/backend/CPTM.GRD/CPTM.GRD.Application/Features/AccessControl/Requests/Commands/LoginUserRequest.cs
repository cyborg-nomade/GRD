using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Responses;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class LoginUserRequest : IRequest<AuthResponse>
{
    public AuthUser AuthUser { get; init; } = new AuthUser();
}