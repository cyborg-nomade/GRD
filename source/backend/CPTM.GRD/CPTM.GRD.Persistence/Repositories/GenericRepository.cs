using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CPTM.GRD.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly GrdContext _grdContext;

    public GenericRepository(GrdContext grdContext)
    {
        _grdContext = grdContext;
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _grdContext.Set<T>().ToListAsync();
    }

    public async Task<T?> Get(int id)
    {
        return await _grdContext.FindAsync<T>(id);
    }

    public Task<T> Add(T entity)
    {
        //await _grdContext.AddAsync(entity);
        //return entity;
        _grdContext.Set<T>().Update(entity);
        return Task.FromResult(entity);
    }

    public Task<T> Update(T entity)
    {
        _grdContext.Set<T>().Update(entity);
        return Task.FromResult(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _grdContext.FindAsync<T>(id);
        if (entity == null) throw new NotFoundException(nameof(entity), id);
        _grdContext.Set<T>().Remove(entity);
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }
}