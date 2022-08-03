using CPTM.GRD.Application.DTOs.Main.Mixed;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class AddProposicaoToReuniaoRequest : BasicRequest, IRequest<AddProposicaoToReuniaoDto>
{
    public int Pid { get; init; }
    public int Rid { get; init; }
}