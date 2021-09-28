using Pubs.SharedKernel.Entities;
using System.Collections.Generic;

namespace Pubs.Application.Interfaces.Repositories.Common
{
    public interface IReadOnlyRepository<T, TKey> where T : BaseEntity
    {
        T GetById(TKey id);

        IReadOnlyList<T> ListAll();
    }
}
