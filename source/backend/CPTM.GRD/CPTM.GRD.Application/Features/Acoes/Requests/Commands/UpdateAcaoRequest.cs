using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class UpdateAcaoRequest : IRequest<AcaoDto>
{
    public UpdateAcaoDto UpdateAcaoDto { get; set; } = new UpdateAcaoDto();
    public int Uid { get; set; }
}