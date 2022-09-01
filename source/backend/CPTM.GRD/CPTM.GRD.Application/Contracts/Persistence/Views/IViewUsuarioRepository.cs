namespace CPTM.GRD.Application.Contracts.Persistence.Views;

public interface IViewUsuarioRepository
{
    Task<int> GetCodigoCpu(string username);

    Task<string?> GetCargoCpu(string username);
}