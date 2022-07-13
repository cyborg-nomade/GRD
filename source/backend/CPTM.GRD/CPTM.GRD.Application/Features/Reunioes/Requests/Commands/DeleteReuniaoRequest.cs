using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Commands;

public class DeleteReuniaoRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public int Uid { get; set; }
}