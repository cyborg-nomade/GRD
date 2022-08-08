using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class DeleteReuniaoRequest : BasicRequest, IRequest<Unit>
{
    public int Rid { get; init; }
}