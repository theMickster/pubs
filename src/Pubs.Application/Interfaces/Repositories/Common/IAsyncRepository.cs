using System.Collections.Generic;
using System.Threading.Tasks;
using Pubs.SharedKernel.Entities;

namespace Pubs.Application.Interfaces.Repositories.Common
{
    public interface IAsyncRepository<T, TKey> where T : BaseEntity
    {
        Task<T> GetByIdAsync(TKey id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
