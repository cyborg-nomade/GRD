using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class UpdateReuniaoRequest : IRequest<ReuniaoDto>
{
    public ReuniaoDto ReuniaoDto { get; set; } = new ReuniaoDto();
    public int Uid { get; set; }
}