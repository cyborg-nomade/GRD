using System.Diagnostics.CodeAnalysis;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;

namespace CPTM.GRD.Domain.Logging;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
public class LogAcao
{
    public int Id { get; set; }
    public TipoLogAcao Tipo { get; set; }
    public string AcaoRef { get; set; } = string.Empty;
    public string Diferenca { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public User? Resp { get; set; }

    private LogAcao()
    {
    }

    public LogAcao(Acao acao, TipoLogAcao tipoLogAcao, string diferenca, User responsavel)
    {
        Data = DateTime.Now;
        Tipo = tipoLogAcao;
        Diferenca = diferenca;
        AcaoRef = $@"ID Ação: {acao.Id}";
        Resp = responsavel;
    }
}