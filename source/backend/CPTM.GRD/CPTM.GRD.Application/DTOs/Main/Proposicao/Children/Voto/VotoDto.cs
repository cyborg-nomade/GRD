using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;

public class VotoDto : IBaseVotoDto, IFullVotoDto
{
    public int Id { get; set; }
    public UserDto Participante { get; set; } = new UserDto();
    public TipoVotoRd VotoRd { get; set; }

    public override string ToString()
    {
        return @$"{nameof(Id)}: {Id}, 
{nameof(Participante)}: {Participante}, 
{nameof(VotoRd)}: {VotoRd}";
    }
}