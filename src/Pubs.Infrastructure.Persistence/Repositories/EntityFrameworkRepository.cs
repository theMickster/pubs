using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.SharedKernel.Entities;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public abstract class EntityFrameworkRepository<T, TKey> : IRepository<T, TKey>, IAsyncRepository<T, TKey>, IEntityFrameworkRepository<T> where T : BaseEntity
    {
        protected readonly PubsContext DbContext;

        protected EntityFrameworkRepository(PubsContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public T GetById(TKey id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public IReadOnlyList<T> ListAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public async Task<T> AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();

            return entity;
        }

        public T Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChanges();
        }

        public EntityEntry<T> GetDbEntityEntry(T entity)
        {
            return DbContext.Entry(entity);
        }
    }
}