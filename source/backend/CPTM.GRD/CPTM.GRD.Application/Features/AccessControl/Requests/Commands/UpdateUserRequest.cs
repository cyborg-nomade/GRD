using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class UpdateUserRequest : IRequest<UserDto>
{
    public UpdateUserDto UpdateUserDto { get; set; } = new UpdateUserDto();
}