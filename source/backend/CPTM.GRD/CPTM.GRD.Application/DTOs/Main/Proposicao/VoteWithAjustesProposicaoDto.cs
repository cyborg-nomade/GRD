using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao;

public class VoteWithAjustesProposicaoDto
{
    public VotoDto VotoDto { get; set; } = new VotoDto();
    public string Ajustes { get; set; } = string.Empty;
}