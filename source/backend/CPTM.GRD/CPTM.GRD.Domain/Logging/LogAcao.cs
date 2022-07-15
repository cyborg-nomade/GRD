using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Logging;

public class LogAcao
{
    public int Id { get; set; }
    public TipoLogAcao Tipo { get; set; }
    public string AcaoId { get; set; } = string.Empty;
    public string Diferenca { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public User UsuarioResp { get; set; } = new User();

    public LogAcao(Acao acao, TipoLogAcao tipoLogAcao, string diferenca)
    {
        Data = DateTime.Now;
        Tipo = tipoLogAcao;
        Diferenca = diferenca;
        AcaoId = $@"ID Ação: {acao.Id}";
        UsuarioResp = acao.Responsavel;
    }
}