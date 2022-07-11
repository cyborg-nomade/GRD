using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Logging;

public class LogReuniaoDto
{
    public int Id { get; set; }
    public TipoLogReuniao Tipo { get; set; }
    public ReuniaoDto Reuniao { get; set; } = new ReuniaoDto();
    public ReuniaoDto Diferenca { get; set; } = new ReuniaoDto();
    public DateTime Data { get; set; }
    public UserDto UsuarioResp { get; set; } = new UserDto();
}