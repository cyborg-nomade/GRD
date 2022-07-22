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
        return await _grdContext.Set<T>().FindAsync(id);
    }

    public async Task<T> Add(T entity)
    {
        await _grdContext.AddAsync(entity);
        await _grdContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        _grdContext.Set<T>().Update(entity);
        await _grdContext.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _grdContext.FindAsync<T>(id);
        if (entity == null) throw new NotFoundException(nameof(entity), id);
        _grdContext.Set<T>().Remove(entity);
        await _grdContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }
}