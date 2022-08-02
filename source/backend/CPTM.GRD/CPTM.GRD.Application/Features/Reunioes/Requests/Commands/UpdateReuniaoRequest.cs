using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class UpdateReuniaoRequest : IRequest<ReuniaoDto>
{
    public int Rid { get; init; }
    public UpdateReuniaoDto UpdateReuniaoDto { get; init; } = new UpdateReuniaoDto();
    public int Uid { get; init; }
}