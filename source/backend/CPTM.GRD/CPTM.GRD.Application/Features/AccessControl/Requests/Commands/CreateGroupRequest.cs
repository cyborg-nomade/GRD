using CPTM.GRD.Application.DTOs.AccessControl.Group;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class CreateGroupRequest : BasicRequest, IRequest<GroupDto>
{
    public string Sigla { get; set; } = string.Empty;
}