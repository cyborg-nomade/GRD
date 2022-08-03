using CPTM.GRD.Application.DTOs.Main.Mixed;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class RemoveAcaoFromReuniaoRequest : BasicRequest, IRequest<AddAcaoToReuniaoDto>
{
    public int Aid { get; init; }
    public int Rid { get; init; }
    public int Uid { get; init; }
}