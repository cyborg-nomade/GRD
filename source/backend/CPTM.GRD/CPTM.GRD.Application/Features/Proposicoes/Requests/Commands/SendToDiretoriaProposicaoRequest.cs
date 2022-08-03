using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class SendToDiretoriaProposicaoRequest : BasicRequest, IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
}