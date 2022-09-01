using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Queries;

public class GetByReuniaoAcoesListRequest : BasicRequest, IRequest<List<AcaoListDto>>
{
    public int Rid { get; init; }
}