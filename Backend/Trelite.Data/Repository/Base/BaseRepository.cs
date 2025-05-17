using System;
using Microsoft.EntityFrameworkCore;
using Trelite.Data.DbContext;

namespace Trelite.Data.Repository.Base;

public class BaseRepository<T>  where T : class
{
    protected readonly AppDbContext _appDbContext;
    protected readonly DbSet<T> _dbset;
    public BaseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbset = _appDbContext.Set<T>();
    }
    public async Task<T> GetByIdAsync(object id)
    {
       return await _dbset.FindAsync(id);
    }
     public async Task<List<T>> GetAsync()
    {
       return await _dbset.ToListAsync();
    }
    public async Task<T> PostAsync(T entity)
    {
        await _dbset.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity; 
    }
     public async Task<T> UpdateAsync(T entity)
    {
        _dbset.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity; 
    }
}
