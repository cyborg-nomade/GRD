using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao;

public class AddDiretorVoteToProposicaoDto
{
    public ParticipanteDto ParticipanteDto { get; set; } = new ParticipanteDto();
    public TipoVotoRd VotoRd { get; set; }
    public string Ajustes { get; set; } = string.Empty;
}