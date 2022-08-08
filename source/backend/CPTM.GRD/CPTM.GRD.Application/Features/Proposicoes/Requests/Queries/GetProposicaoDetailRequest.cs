using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetProposicaoDetailRequest : BasicRequest, IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
}