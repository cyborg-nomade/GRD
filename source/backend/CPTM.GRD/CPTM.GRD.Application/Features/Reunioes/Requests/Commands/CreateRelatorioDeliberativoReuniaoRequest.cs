using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class CreateRelatorioDeliberativoReuniaoRequest : BasicRequest, IRequest<ReuniaoDto>
{
    public int Rid { get; init; }
    public int Uid { get; init; }
}