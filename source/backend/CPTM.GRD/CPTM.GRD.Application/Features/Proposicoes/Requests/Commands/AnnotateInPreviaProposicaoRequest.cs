using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class AnnotateInPreviaProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
    public int Uid { get; init; }
    public string Anotacao { get; init; } = string.Empty;
}