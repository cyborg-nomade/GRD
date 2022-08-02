using System.Security.Claims;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class DeleteUserRequest : BasicRequest, IRequest<Unit>
{
    public int Uid { get; init; }
}