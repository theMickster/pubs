using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pubs.SharedKernel.Entities;

namespace Pubs.Application.Common.Interfaces
{
    public interface IEntityFrameworkRepository<T> where T : BaseEntity
    {
        EntityEntry<T> GetDbEntityEntry(T entity);
    }
}