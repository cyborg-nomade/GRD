using CPTM.GRD.Application.Contracts.Persistence.Views;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories.Views;

public class ViewUsuarioRepository : IViewUsuarioRepository
{
    private readonly GrdContext _grdContext;

    public ViewUsuarioRepository(GrdContext grdContext)
    {
        _grdContext = grdContext;
    }

    public async Task<int> GetCodigoCPU(string username)
    {
        return await _grdContext.GrdVwUsuarios.Where(u => u.TxUsername == username.ToUpper())
            .Select(u => u.IdCodusuario)
            .SingleOrDefaultAsync();
    }

    public async Task<string?> GetCargoCPU(string username)
    {
        return await _grdContext.GrdVwUsuarios.Where(u => u.TxUsername == username.ToUpper())
            .Select(u => u.TxCargo)
            .SingleOrDefaultAsync();
    }
}