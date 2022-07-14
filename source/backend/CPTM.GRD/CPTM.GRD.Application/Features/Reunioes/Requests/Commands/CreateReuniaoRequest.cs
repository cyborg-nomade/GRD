using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class CreateReuniaoRequest : IRequest<ReuniaoDto>
{
    public int Uid { get; set; }
    public CreateReuniaoDto CreateReuniaoDto { get; set; } = new CreateReuniaoDto();
}