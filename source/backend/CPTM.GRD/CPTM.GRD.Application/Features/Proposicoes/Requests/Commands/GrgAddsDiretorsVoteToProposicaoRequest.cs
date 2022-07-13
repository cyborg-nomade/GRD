using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class GrgAddsDiretorsVoteToProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; set; }
    public List<AddDiretorVoteToProposicaoDto> Votes { get; set; } = new List<AddDiretorVoteToProposicaoDto>();
}