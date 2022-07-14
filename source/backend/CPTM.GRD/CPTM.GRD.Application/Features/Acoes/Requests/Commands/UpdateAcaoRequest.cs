using CPTM.GRD.Application.DTOs.Main.Acao;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class UpdateAcaoRequest : IRequest<AcaoDto>
{
    public AcaoDto AcaoDto { get; set; } = new AcaoDto();
}