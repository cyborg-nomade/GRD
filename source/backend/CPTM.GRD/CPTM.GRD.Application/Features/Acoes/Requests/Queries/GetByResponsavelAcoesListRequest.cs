using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Queries;

public class GetByResponsavelAcoesListRequest : BasicRequest, IRequest<List<AcaoListDto>>
{
    public int Reid { get; set; }
}