using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class UpdateAcaoRequest : BasicRequest, IRequest<AcaoDto>
{
    public int Aid { get; init; }
    public UpdateAcaoDto UpdateAcaoDto { get; init; } = new UpdateAcaoDto();
}