namespace CPTM.GRD.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Get(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Delete(int id);
    Task<bool> Exists(int id);
}