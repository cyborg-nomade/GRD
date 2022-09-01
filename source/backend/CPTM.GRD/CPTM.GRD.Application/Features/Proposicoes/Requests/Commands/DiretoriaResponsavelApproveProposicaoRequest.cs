using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class DiretoriaResponsavelApproveProposicaoRequest : BasicRequest, IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
}