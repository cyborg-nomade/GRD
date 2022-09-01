using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class CreateAcaoRequest : BasicRequest, IRequest<AcaoDto>
{
    public CreateAcaoDto CreateAcaoDto { get; init; } = new CreateAcaoDto();
    public int Rid { get; init; }
}