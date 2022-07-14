using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class CreateProposicaoRequest : IRequest<ProposicaoDto>
{
    public CreateProposicaoDto CreateProposicaoDto { get; set; } = new CreateProposicaoDto();
}