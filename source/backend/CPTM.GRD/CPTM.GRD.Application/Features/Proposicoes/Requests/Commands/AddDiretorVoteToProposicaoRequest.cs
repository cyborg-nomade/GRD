using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class AddDiretorVoteToProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; init; }

    public List<VoteWithAjustesProposicaoDto> VotesWithAjustes { get; init; } =
        new List<VoteWithAjustesProposicaoDto>();
}