using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class UpdateReuniaoRequest : IRequest<ReuniaoDto>
{
    public UpdateReuniaoDto UpdateReuniaoDto { get; set; } = new UpdateReuniaoDto();
    public int Uid { get; set; }
}