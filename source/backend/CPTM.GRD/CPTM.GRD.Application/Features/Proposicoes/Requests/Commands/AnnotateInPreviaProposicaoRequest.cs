using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class AnnotateInPreviaProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; set; }
    public int Uid { get; set; }
    public string Anotacao { get; set; } = string.Empty;
}