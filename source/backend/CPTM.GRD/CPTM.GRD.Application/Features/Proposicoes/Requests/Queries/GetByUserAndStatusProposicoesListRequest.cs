using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetByUserAndStatusProposicoesListRequest : IRequest<List<ProposicaoListDto>>
{
    public int Uid { get; set; }
    public ProposicaoStatus Status { get; set; }
    public bool Arquivada { get; set; }
}