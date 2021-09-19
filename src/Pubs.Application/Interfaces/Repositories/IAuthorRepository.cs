using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.CoreDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pubs.Application.Interfaces.Repositories
{
    public interface IAuthorRepository : IAsyncRepository<Author, int>
    {
        /// <summary>
        /// Retrieves a list of all authors.
        /// </summary>
        /// <returns></returns>
        Task<List<Author>> GetAuthorsAsync();

        /// <summary>
        /// Retrieves a particular author by its identifier
        /// </summary>
        /// <param name="id">the author's identifier</param>
        /// <returns></returns>
        Task<Author> GetAuthorAsync(int id);

    }
}
