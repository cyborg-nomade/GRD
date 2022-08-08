using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class DeleteProposicaoRequest : BasicRequest, IRequest
{
    public int Pid { get; init; }
}