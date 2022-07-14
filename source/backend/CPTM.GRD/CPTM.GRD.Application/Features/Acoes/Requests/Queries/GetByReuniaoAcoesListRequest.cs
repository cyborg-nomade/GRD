using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Queries;

public class GetByReuniaoAcoesListRequest : IRequest<List<AcaoListDto>>
{
    public int Rid { get; set; }
}