using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Logging;

public class LogProposicaoDto
{
    public int Id { get; set; }
    public TipoLogProposicao Tipo { get; set; }
    public string ProposicaoId { get; set; } = string.Empty;
    public string Diferenca { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public UserDto UsuarioResp { get; set; } = new UserDto();
}