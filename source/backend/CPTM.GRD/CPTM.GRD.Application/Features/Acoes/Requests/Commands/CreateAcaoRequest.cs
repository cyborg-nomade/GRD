using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class CreateAcaoRequest : IRequest<AcaoDto>
{
    public CreateAcaoDto CreateAcaoDto { get; set; } = new CreateAcaoDto();
    public int Rid { get; set; }
    public int Uid { get; set; }
}