using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Queries;

public class GetAcaoDetailRequest : BasicRequest, IRequest<AcaoDto>
{
    public int Aid { get; init; }
}