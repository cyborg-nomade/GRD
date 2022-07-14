using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Queries;

public class GetAllAcoesListRequest : IRequest<List<AcaoListDto>>
{
}