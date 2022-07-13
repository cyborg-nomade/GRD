using CPTM.GRD.Application.DTOs.Main.Reuniao;
using MediatR;

namespace CPTM.GRD.Application.Features.Reunioes.Requests.Queries;

public class GetReuniaoDetailRequest : IRequest<ReuniaoDto>
{
    public int Id { get; set; }
}