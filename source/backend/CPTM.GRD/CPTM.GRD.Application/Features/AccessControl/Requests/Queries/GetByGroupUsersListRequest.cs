using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetByGroupUsersListRequest : BasicRequest, IRequest<List<UserDto>>
{
    public int Gid { get; init; }
}