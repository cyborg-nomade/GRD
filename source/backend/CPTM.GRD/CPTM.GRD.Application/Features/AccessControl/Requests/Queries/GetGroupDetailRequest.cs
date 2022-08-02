using CPTM.GRD.Application.DTOs.AccessControl.Group;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetGroupDetailRequest : BasicRequest, IRequest<GroupDto>
{
    public int Gid { get; set; }
}