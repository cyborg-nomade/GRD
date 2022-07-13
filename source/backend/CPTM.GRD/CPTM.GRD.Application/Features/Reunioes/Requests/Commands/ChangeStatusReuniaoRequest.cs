using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class ChangeStatusReuniaoRequest : IRequest<ReuniaoDto>
{
    public int Rid { get; set; }
    public int Uid { get; set; }
    public ReuniaoStatus NewStatus { get; set; }
    public TipoLogReuniao TipoLogReuniao { get; set; }
}