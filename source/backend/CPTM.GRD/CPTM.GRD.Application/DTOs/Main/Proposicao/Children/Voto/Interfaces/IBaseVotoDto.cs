using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto.Interfaces;

public interface IBaseVotoDto
{
    public UserDto Participante { get; set; }
    public TipoVotoRd VotoRd { get; set; }
}