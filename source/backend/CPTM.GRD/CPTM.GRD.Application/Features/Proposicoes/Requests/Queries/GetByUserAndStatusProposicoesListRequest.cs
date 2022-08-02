using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetByUserAndStatusProposicoesListRequest : IRequest<List<ProposicaoListDto>>
{
    public int Uid { get; init; }
    public ProposicaoStatus Status { get; init; }
    public bool Arquivada { get; init; }
}