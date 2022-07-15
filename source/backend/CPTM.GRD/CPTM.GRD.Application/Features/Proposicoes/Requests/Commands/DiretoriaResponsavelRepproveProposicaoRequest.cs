using CPTM.GRD.Application.DTOs.Main.Proposicao;
using MediatR;

namespace CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;

public class DiretoriaResponsavelRepproveProposicaoRequest : IRequest<ProposicaoDto>
{
    public int Pid { get; set; }
    public int Uid { get; set; }
    public string MotivoReprovacao { get; set; } = string.Empty;
}