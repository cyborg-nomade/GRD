using System.Security.Claims;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class UpdateUserRequest : IRequest<UserDto>
{
    public ClaimsPrincipal RequestUser { get; set; } = new ClaimsPrincipal();
    public UpdateUserDto UpdateUserDto { get; set; } = new UpdateUserDto();
}