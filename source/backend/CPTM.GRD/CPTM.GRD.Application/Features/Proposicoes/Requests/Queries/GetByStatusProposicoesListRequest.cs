using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetByStatusProposicoesListRequest : IRequest<List<ProposicaoListDto>>
{
    public ProposicaoStatus Status { get; set; }
}