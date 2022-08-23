using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;

public class VotoDto : IBaseVotoDto, IFullVotoDto
{
    public int Id { get; set; }
    public int ParticipanteId { get; set; }
    public TipoVotoRd VotoRd { get; set; }

    public override string ToString()
    {
        return @$"{nameof(Id)}: {Id}, 
{nameof(ParticipanteId)}: {ParticipanteId}, 
{nameof(VotoRd)}: {VotoRd}";
    }
}