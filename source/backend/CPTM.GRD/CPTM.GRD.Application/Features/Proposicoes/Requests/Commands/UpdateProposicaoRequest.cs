using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class UpdateProposicaoRequest : BasicRequest, IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
    public UpdateProposicaoDto UpdateProposicaoDto { get; init; } = new UpdateProposicaoDto();
    public int Uid { get; init; }
}