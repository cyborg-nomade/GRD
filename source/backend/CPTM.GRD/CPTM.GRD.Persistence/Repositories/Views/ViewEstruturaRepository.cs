using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Domain.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.Views;

public class ViewEstruturaRepository : IViewEstruturaRepository
{
    private readonly GrdContext _grdContext;

    public ViewEstruturaRepository(GrdContext grdContext)
    {
        _grdContext = grdContext;
    }

    public async Task<Group> GetGroup(string sigla)
    {
        var grupoEstrutura = await _grdContext.GrdVwEstruturasOrg.FirstOrDefaultAsync(eg =>
            eg.FlAtivo == 1 &&
            (eg.NrNivel >= 1 && eg.NrNivel <= 4) &&
            (eg.DirSigla == sigla || eg.GgSigla == sigla || eg.GerSigla == sigla || eg.DepSigla == sigla));
        if (grupoEstrutura == null) throw new NotFoundException(nameof(grupoEstrutura), nameof(sigla));
        var group = new Group
        {
            Nome = grupoEstrutura.TxNome ?? throw new InvalidOperationException(),
            Sigla = sigla,
            Diretoria = grupoEstrutura.DirSigla ?? throw new InvalidOperationException(),
            SiglaDiretoria = grupoEstrutura.DirSigla,
            Gerencia = grupoEstrutura.GerSigla ?? throw new InvalidOperationException(),
            SiglaGerencia = grupoEstrutura.GerSigla,
        };
        return group;
    }
}