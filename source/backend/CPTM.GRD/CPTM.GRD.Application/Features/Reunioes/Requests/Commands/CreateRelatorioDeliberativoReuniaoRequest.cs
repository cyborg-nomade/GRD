using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class CreateRelatorioDeliberativoReuniaoRequest : IRequest<ReuniaoDto>
{
    public int Rid { get; set; }
    public int Uid { get; set; }
}