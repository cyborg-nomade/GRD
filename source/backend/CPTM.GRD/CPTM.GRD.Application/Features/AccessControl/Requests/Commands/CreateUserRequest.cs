using System.Security.Claims;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class CreateUserRequest : IRequest<UserDto>
{
    public ClaimsPrincipal RequestUser { get; set; } = new ClaimsPrincipal();
    public CreateUserDto CreateUserDto { get; init; } = new CreateUserDto();
}