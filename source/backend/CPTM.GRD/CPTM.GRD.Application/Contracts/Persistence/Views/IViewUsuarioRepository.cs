namespace CPTM.GRD.Application.Contracts.Persistence.Views;

public interface IViewUsuarioRepository
{
    Task<int> GetCodigoCPU(string username);

    Task<string?> GetCargoCPU(string username);
}