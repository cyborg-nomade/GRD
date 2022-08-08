using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;

namespace CPTM.GRD.Application.DTOs.Main.Mixed;

public class AddProposicaoToReuniaoDto
{
    public ProposicaoDto ProposicaoDto { get; init; } = new ProposicaoDto();
    public ReuniaoDto ReuniaoDto { get; init; } = new ReuniaoDto();
}