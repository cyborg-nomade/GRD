using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetProposicaoDetailRequest : IRequest<ProposicaoDto>
{
    public int Id { get; set; }
}