using CPTM.GRD.Application.DTOs.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class UpdateUserRequest : IRequest<UserDto>
{
    public UserDto UserDto { get; set; } = new UserDto();
}