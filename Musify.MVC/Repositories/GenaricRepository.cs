using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using System.Runtime.CompilerServices;

namespace Musify.MVC.Repositories;

public class Genaricepository<T> : IGenaricRepository<T> where T : class
{
    private readonly MusifyDbContext _dbContext;

    public Genaricepository(MusifyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await Save();
    }

    public async Task Delete(Guid id)
    {
        _dbContext.Remove(id);
        await Save();
    }

    public async Task<T> Get(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id) ?? default!;
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<int> Save()
    {
        int result = await _dbContext.SaveChangesAsync();//TODO:Check return value 
        return result;
    }

    public async Task Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await Save();
    }
}
