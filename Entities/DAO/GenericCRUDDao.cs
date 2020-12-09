using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Entities.DAO
{
  public abstract class GenericCRUDDao<TEntity, Tpk> where TEntity: class
  {
    private readonly DbSet<TEntity> _dbset;
    private readonly DbContext _dbContext;

    protected GenericCRUDDao(DbSet<TEntity> dbSet, DbContext dbContext)
    {
      _dbset = dbSet;
      _dbContext = dbContext;
    }

    public async Task<TEntity> SaveNew(Func<TEntity> provideValue)
    {
      var initial = provideValue();
      var result = _dbset.AddAsync(initial).AsTask().ContinueWith<TEntity>((arg) => arg.Result.Entity);
      await _dbContext.SaveChangesAsync();
      return await result;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
      return await _dbset.ToListAsync<TEntity>();
    }

    public async Task<TEntity> GetOne(Tpk key)
    {
      return await _dbset.FindAsync(key);
    }

    public async Task<bool> Delete(Tpk id)
    {
      TEntity ent = _dbset.Find(id);

      EntityEntry<TEntity>? entry = ent != null ? _dbset.Remove(ent) : null;
      var state = entry == null ?  0 : await _dbContext.SaveChangesAsync();

      return state > 0 && EntityState.Deleted.Equals(entry?.State);

    }
  }
}
