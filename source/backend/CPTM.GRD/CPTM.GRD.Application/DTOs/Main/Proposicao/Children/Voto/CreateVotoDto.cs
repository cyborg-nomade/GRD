using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;

public class CreateVotoDto : IBaseVotoDto
{
    public UserDto Participante { get; set; } = new UserDto();
    public TipoVotoRd VotoRd { get; set; }
}