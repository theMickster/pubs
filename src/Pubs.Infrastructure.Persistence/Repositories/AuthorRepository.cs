using Microsoft.EntityFrameworkCore;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : EntityFrameworkRepository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(PubsContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Retrieves a particular author by its identifier
        /// </summary>
        /// <param name="id">the author's identifier</param>
        /// <returns></returns>
        public async Task<Author> GetAuthorAsync(int id)
        {
            return await DbContext.Authors
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Retrieves a list of all authors.
        /// </summary>
        /// <returns></returns>
        public async  Task<List<Author>> GetAuthorsAsync()
        {
            return await DbContext.Authors.ToListAsync();
        }
    }
}
