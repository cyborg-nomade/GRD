using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Logging;

public class LogProposicaoDto
{
    public int Id { get; set; }
    public TipoLogProposicao Tipo { get; set; }
    public ProposicaoDto Proposicao { get; set; } = new ProposicaoDto();
    public ProposicaoDto Diferenca { get; set; } = new ProposicaoDto();
    public DateTime Data { get; set; }
    public UserDto UsuarioResp { get; set; } = new UserDto();
}