namespace CPTM.GRD.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Get(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Delete(int id);

}