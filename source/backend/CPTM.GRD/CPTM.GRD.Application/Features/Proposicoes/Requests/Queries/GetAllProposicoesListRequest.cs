using CPTM.GRD.Application.DTOs.Lists;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;

public class GetAllProposicoesListRequest : IRequest<List<ProposicaoListDto>>
{

}