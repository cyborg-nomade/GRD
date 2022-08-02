using System.Security.Claims;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class DeleteUserRequest : IRequest<Unit>
{
    public ClaimsPrincipal RequestUser { get; set; } = new ClaimsPrincipal();
    public int Uid { get; set; }
}