using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class ChangeStatusProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Id { get; set; }
    public ProposicaoStatus NewStatus { get; set; }
}