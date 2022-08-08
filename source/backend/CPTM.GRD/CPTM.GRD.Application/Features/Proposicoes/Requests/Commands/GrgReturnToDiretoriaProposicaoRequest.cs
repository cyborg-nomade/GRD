using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class GrgReturnToDiretoriaProposicaoRequest : BasicRequest, IRequest<ProposicaoDto>
{
    public int Pid { get; init; }
    public string MotivoReprovacao { get; init; } = string.Empty;
}