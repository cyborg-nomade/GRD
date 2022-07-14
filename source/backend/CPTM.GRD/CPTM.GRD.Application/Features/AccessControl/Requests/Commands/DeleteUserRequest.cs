using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Commands;

public class DeleteUserRequest : IRequest<Unit>
{
    public int Uid { get; set; }
}