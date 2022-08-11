using CPTM.GRD.Application.Contracts.Persistence.Views;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Responses;
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
            Gerencia = grupoEstrutura.GerSigla ?? grupoEstrutura.DirSigla,
            SiglaGerencia = grupoEstrutura.GerSigla ?? grupoEstrutura.DirSigla,
        };
        return group;
    }

    public async Task<EstruturaResponse> GetEstrutura()
    {
        var diretorias = await _grdContext.GrdVwEstruturasOrg
            .Where(os =>
                os.FlAtivo == 1 &&
                os.CdTipoEstrutura == "DIR" &&
                os.TxSigla != "CED" &&
                os.TxSigla != "APOS" &&
                os.TxSigla != "LICSVENC")
            .Select(os => os.DirSigla)
            .Distinct()
            .OrderBy(s => s.Trim()
                .ToLower())
            .ToListAsync();
        var gerenciasGerais = await _grdContext.GrdVwEstruturasOrg
            .Where(os =>
                os.FlAtivo == 1 &&
                os.CdTipoEstrutura == "GG" &&
                os.TxSigla != "CED" &&
                os.TxSigla != "APOS" &&
                os.TxSigla != "LICSVENC")
            .OrderBy(os => os.DirSigla)
            .Select(os => os.GgSigla)
            .Distinct()
            .OrderBy(s => s.Trim()
                .ToLower())
            .ToListAsync();
        var gerencias = await _grdContext.GrdVwEstruturasOrg
            .Where(os =>
                os.FlAtivo == 1 &&
                os.CdTipoEstrutura == "GER" &&
                os.TxSigla != "CED" &&
                os.TxSigla != "APOS" &&
                os.TxSigla != "LICSVENC")
            .OrderBy(os => os.DirSigla)
            .Select(os => os.GerSigla)
            .Distinct()
            .OrderBy(s => s.Trim()
                .ToLower())
            .ToListAsync();
        var departamentos = await _grdContext.GrdVwEstruturasOrg
            .Where(os =>
                os.FlAtivo == 1 &&
                os.CdTipoEstrutura == "D" &&
                os.TxSigla != "CED" &&
                os.TxSigla != "APOS" &&
                os.TxSigla != "LICSVENC")
            .OrderBy(os => os.DirSigla)
            .Select(os => os.DepSigla)
            .Distinct()
            .OrderBy(s => s.Trim()
                .ToLower())
            .ToListAsync();


        return new EstruturaResponse()
        {
            Departamentos = departamentos,
            Diretorias = diretorias,
            Gerencias = gerencias,
            GerenciasGerais = gerenciasGerais
        };
    }
}