using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main;

public class VotoDto
{
    public int Id { get; set; }
    public ParticipanteDto Participante { get; set; } = new ParticipanteDto();
    public TipoVotoRd VotoRd { get; set; }
}