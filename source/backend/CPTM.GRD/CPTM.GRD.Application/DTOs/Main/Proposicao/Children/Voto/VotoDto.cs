using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;

public class VotoDto : IVotoDto
{
    public int Id { get; set; }
    public ParticipanteDto Participante { get; set; } = new ParticipanteDto();
    public TipoVotoRd VotoRd { get; set; }
}