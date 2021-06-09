using Microsoft.EntityFrameworkCore;
using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.SharedKernel.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public abstract class ReadOnlyEntityFrameworkRepository<T, TKey> : IReadOnlyRepository<T, TKey>, IReadOnlyAsyncRepository<T, TKey> where T : BaseEntity
    {
        protected readonly PubsContext DbContext;

        protected ReadOnlyEntityFrameworkRepository(PubsContext dbContext)
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
    }
}
