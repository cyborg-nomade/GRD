using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetByUserProposicoesListRequest : IRequest<List<ProposicaoListDto>>
{
    public int Uid { get; init; }
}