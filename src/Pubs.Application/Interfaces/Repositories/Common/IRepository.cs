using Pubs.SharedKernel.Entities;
using System.Collections.Generic;

namespace Pubs.Application.Interfaces.Repositories.Common
{
    public interface IRepository<T, TKey> where T : BaseEntity
    {
        T GetById(TKey id);

        IReadOnlyList<T> ListAll();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
