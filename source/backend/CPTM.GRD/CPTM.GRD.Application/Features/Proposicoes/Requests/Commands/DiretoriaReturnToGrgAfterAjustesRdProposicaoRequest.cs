using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class DiretoriaReturnToGrgAfterAjustesRdProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
    public int Uid { get; init; }
}