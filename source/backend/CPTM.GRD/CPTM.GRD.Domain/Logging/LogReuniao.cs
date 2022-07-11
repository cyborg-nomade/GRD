using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Logging;

public class LogReuniao
{
    public int Id { get; set; }
    public TipoLogReuniao Tipo { get; set; }
    public Reuniao Reuniao { get; set; } = new Reuniao();
    public Reuniao Diferenca { get; set; } = new Reuniao();
    public DateTime Data { get; set; }
    public User UsuarioResp { get; set; } = new User();
}