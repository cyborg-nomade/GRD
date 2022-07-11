using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Logging;

public class LogAcao
{
    public int Id { get; set; }
    public TipoLogAcao Tipo { get; set; }
    public Acao Acao { get; set; } = new Acao();
    public Acao Diferenca { get; set; } = new Acao();
    public DateTime Data { get; set; }
    public User UsuarioResp { get; set; } = new User();
}