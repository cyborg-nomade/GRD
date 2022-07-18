using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao;

public class VoteWithAjustesProposicaoDto
{
    public CreateVotoDto VotoDto { get; set; } = new CreateVotoDto();
    public string Ajustes { get; set; } = string.Empty;
}