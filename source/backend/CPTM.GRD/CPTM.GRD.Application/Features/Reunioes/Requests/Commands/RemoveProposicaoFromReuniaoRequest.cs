using CPTM.GRD.Application.DTOs.Main.Mixed;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class RemoveProposicaoFromReuniaoRequest : IRequest<AddProposicaoToReuniaoDto>
{
    public int Rid { get; init; }
    public int Pid { get; init; }
    public int Uid { get; init; }
}