using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetByGroupAndLevelUsersListRequest : BasicRequest, IRequest<List<UserDto>>
{
    public int Gid { get; init; }
    public AccessLevel Level { get; init; }
}