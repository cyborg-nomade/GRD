using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Logging;

public class LogAcaoDto
{
    public int Id { get; set; }
    public TipoLogAcao Tipo { get; set; }
    public AcaoDto Acao { get; set; } = new AcaoDto();
    public string Diferenca { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public UserDto UsuarioResp { get; set; } = new UserDto();
}