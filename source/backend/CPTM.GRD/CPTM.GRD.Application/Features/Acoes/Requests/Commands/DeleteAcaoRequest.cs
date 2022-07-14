using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class DeleteAcaoRequest : IRequest<Unit>
{
    public int Aid { get; set; }
    public int Uid { get; set; }
}