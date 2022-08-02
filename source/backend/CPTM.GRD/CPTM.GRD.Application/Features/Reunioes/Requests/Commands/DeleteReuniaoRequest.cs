using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class DeleteReuniaoRequest : IRequest<Unit>
{
    public int Rid { get; init; }
    public int Uid { get; init; }
}