using CPTM.GRD.Application.DTOs;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class CreateProposicaoCommand : IRequest<int>
{
    public ProposicaoDto ProposicaoDto { get; set; }
}