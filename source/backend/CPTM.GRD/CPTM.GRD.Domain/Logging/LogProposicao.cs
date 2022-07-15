using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Domain.Logging;

public class LogProposicao
{
    public int Id { get; set; }
    public TipoLogProposicao Tipo { get; set; }
    public string ProposicaoId { get; set; }
    public string Diferenca { get; set; }
    public DateTime Data { get; set; }
    public User UsuarioResp { get; set; }

    public LogProposicao(Proposicao proposicao, TipoLogProposicao tipoLogProposicao,
        User responsavel, string diferenca)
    {
        Data = DateTime.Now;
        Tipo = tipoLogProposicao;
        ProposicaoId = $@"IDPRD: {proposicao.IdPrd}";
        Diferenca = diferenca;
        UsuarioResp = responsavel;
    }

    public static TipoLogProposicao ConvertFromTipoVoto(TipoVotoRd tipoVotoRd)
    {
        return tipoVotoRd switch
        {
            TipoVotoRd.Aprovacao => TipoLogProposicao.AprovacaoRd,
            TipoVotoRd.Reprovacao => TipoLogProposicao.ReprovacaoRd,
            TipoVotoRd.Suspensao => TipoLogProposicao.SuspensaoRd,
            TipoVotoRd.Abstencao => TipoLogProposicao.AbstencaoRd,
            _ => throw new ArgumentOutOfRangeException(nameof(tipoVotoRd), tipoVotoRd, null)
        };
    }
}