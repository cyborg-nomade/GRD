using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;

public class CreateVotoDto : IBaseVotoDto
{
    public int ParticipanteId { get; set; }
    public TipoVotoRd VotoRd { get; set; }
}