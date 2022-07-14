using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class DeleteReuniaoRequest : IRequest<Unit>
{
    public int Rid { get; set; }
    public int Uid { get; set; }
}