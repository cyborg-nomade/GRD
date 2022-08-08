using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Proposicoes;

namespace CPTM.GRD.Domain.Logging;

public class LogProposicao
{
    public int Id { get; set; }
    public TipoLogProposicao Tipo { get; set; }
    public string ProposicaoRef { get; set; }
    public string Diferenca { get; set; }
    public DateTime Data { get; set; }
    public User Resp { get; set; }

    private LogProposicao()
    {
    }

    public LogProposicao(Proposicao proposicao, TipoLogProposicao tipoLogProposicao,
        User responsavel, string diferenca)
    {
        Data = DateTime.Now;
        Tipo = tipoLogProposicao;
        ProposicaoRef = $@"IDPRD: {proposicao.IdPrd}";
        Diferenca = diferenca;
        Resp = responsavel;
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