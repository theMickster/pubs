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

        /// <summary>
        /// Determines if a given author code is currently in-use.
        /// </summary>
        /// <param name="authorCode">the author code related to an author.</param>
        /// <returns><c>true</c>if the author code exists, otherwise <c>false</c>.</returns>
        bool IsAuthorCodeInUse(string authorCode);
    }
}
