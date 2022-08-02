using CPTM.GRD.Application.DTOs.AccessControl.Group;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetByUserGroupsListRequest : BasicRequest, IRequest<List<GroupDto>>
{
    public int Uid { get; init; }
}