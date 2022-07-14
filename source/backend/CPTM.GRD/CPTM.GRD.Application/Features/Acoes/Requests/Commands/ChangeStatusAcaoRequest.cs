using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class ChangeStatusAcaoRequest : IRequest<AcaoDto>
{
    public int Aid { get; set; }
    public AcaoStatus NewStatus { get; set; }
    public TipoLogAcao TipoLogAcao { get; set; }
}