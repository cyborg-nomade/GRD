using CPTM.GRD.Application.DTOs;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetProposicaoDetailRequest : IRequest<ProposicaoDto>
{
    public int Id { get; set; }
}