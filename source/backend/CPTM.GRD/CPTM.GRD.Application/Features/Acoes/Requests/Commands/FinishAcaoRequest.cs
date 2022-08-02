using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Requests.Commands;

public class FinishAcaoRequest : IRequest<AcaoDto>
{
    public int Aid { get; init; }
    public AcaoStatus Status { get; init; }
    public int Uid { get; init; }
}