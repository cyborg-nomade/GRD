using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class CreateUserRequest : BasicRequest, IRequest<UserDto>
{
    public CreateUserDto CreateUserDto { get; init; } = new CreateUserDto();
}