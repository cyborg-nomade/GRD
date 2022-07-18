using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetByLevelUsersListRequest : IRequest<List<UserDto>>
{
    public AccessLevel Level { get; set; }
}