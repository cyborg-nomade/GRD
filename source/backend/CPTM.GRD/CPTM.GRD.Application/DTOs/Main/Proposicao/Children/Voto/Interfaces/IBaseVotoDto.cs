using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;

public interface IBaseVotoDto
{
    public ParticipanteDto Participante { get; set; }
    public TipoVotoRd VotoRd { get; set; }
}