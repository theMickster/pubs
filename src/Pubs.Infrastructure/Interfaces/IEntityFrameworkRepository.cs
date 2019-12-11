using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pubs.SharedKernel.Base;

namespace Pubs.Infrastructure.Interfaces
{
    public interface IEntityFrameworkRepository<T> where T : BaseEntity
    {
        EntityEntry<T> GetDbEntityEntry(T entity);
    }
}