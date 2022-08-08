using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetUserDetailRequest : BasicRequest, IRequest<UserDto>
{
    public int Uid { get; init; }
}