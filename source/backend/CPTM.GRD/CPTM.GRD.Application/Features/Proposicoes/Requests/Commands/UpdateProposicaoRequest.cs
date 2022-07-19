using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class UpdateProposicaoRequest : IRequest<ProposicaoDto>
{
    public UpdateProposicaoDto UpdateProposicaoDto { get; set; } = new UpdateProposicaoDto();
    public int Uid { get; set; }
}