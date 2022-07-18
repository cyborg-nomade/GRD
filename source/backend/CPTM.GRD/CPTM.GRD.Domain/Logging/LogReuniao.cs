using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Domain.Logging;

public class LogReuniao
{
    public int Id { get; set; }
    public TipoLogReuniao Tipo { get; set; }
    public string ReuniaoId { get; set; }
    public string Diferenca { get; set; }
    public DateTime Data { get; set; }
    public User UsuarioResp { get; set; }

    public LogReuniao(Reuniao reuniao, TipoLogReuniao tipoLogReuniao, User responsavel, string diferenca)
    {
        Data = DateTime.Now;
        Tipo = tipoLogReuniao;
        ReuniaoId = $@"Número Reunião: {reuniao.NumeroReuniao}";
        Diferenca = diferenca;
        UsuarioResp = responsavel;
    }
}