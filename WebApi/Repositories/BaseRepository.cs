using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using WebApi.Contracts.Persistence;
using WebApi.Helpers;

namespace WebApi.Repositories
{
    public class BaseRepository<T> : IAsyncBaseRepository<T> where T : class
    {
        protected readonly DataContext _dbContext;

        public BaseRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await GetByIdAsync(id);
                if (item == null)
                    return false;
                _dbContext.Set<T>().Remove(item);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);
            return t;
        }


        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task UpdateAsync(int id, T entity)
        {

            EntityEntry entityEntry = _dbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


     /*   public async Task<T> UpdateAsync(int id, T updatedEntity)
        {
            try
            {
                var item = await GetByIdAsync(id);
                if (item == null)
                    throw new KeyNotFoundException($"Item with key {id} not found");
                _dbContext.Entry<T>(updatedEntity).State = EntityState.Modified;
                var updated = await _dbContext.SaveChangesAsync() == 1;
                return updated ? item : null;
            }
            catch (Exception)
            {
                throw;
            }
        }*/
    }
}
