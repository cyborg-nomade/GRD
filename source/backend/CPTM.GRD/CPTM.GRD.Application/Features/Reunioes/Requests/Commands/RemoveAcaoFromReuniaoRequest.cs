using CPTM.GRD.Application.DTOs.Main.Mixed;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class RemoveAcaoFromReuniaoRequest : IRequest<AddAcaoToReuniaoDto>
{
    public int Aid { get; set; }
    public int Rid { get; set; }
    public int Uid { get; set; }
}