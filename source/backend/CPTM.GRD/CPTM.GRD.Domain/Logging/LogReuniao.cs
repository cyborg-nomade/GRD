using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Domain.Logging;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class LogReuniao
{
    public int Id { get; set; }
    public TipoLogReuniao Tipo { get; set; }
    public string ReuniaoRef { get; set; } = string.Empty;
    public string Diferenca { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public User? Resp { get; set; }

    private LogReuniao()
    {
    }

    public LogReuniao(Reuniao reuniao, TipoLogReuniao tipoLogReuniao, User responsavel, string diferenca)
    {
        Data = DateTime.Now;
        Tipo = tipoLogReuniao;
        ReuniaoRef = $@"Número Reunião: {reuniao.NumeroReuniao}";
        Diferenca = diferenca;
        Resp = responsavel;
    }
}