using CPTM.GRD.Application.DTOs.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetAllGroupsListRequest : IRequest<List<GroupDto>>
{
}