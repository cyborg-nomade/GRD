using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;

namespace CPTM.GRD.Application.DTOs.Main.Mixed;

public class AddToPautaDto
{
    public ProposicaoDto ProposicaoDto { get; set; } = new ProposicaoDto();
    public ReuniaoDto ReuniaoDto { get; set; } = new ReuniaoDto();
}