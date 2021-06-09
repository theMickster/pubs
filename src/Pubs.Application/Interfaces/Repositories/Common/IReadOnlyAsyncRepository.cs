using Pubs.SharedKernel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pubs.Application.Interfaces.Repositories.Common
{
    public interface IReadOnlyAsyncRepository<T, TKey> where T : BaseEntity
    {
        Task<T> GetByIdAsync(TKey id);

        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
