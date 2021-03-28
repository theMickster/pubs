using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pubs.SharedKernel.Entities;

namespace Pubs.Application.Interfaces.Repositories.Common
{
    public interface IEntityFrameworkRepository<T> where T : BaseEntity
    {
        EntityEntry<T> GetDbEntityEntry(T entity);
    }
}
