using CPTM.GRD.Application.DTOs.Main.Mixed;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class AddToReuniaoProposicaoRequest : IRequest<AddToPautaDto>
{
    public int Pid { get; set; }
    public int Rid { get; set; }
    public int Uid { get; set; }
}