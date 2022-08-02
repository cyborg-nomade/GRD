using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class DeleteProposicaoRequest : IRequest
{
    public int Pid { get; init; }
}