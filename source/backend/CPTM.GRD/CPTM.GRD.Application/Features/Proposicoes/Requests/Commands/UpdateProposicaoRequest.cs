using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class UpdateProposicaoRequest : IRequest<ProposicaoDto>
{
    public ProposicaoDto ProposicaoDto { get; set; } = new ProposicaoDto();
}