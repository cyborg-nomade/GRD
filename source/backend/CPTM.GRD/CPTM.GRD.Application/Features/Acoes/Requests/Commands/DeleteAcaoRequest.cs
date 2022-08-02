using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class DeleteAcaoRequest : BasicRequest, IRequest<Unit>
{
    public int Aid { get; init; }
}