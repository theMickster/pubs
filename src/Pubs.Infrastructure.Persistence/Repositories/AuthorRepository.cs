using Microsoft.EntityFrameworkCore;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await DbContext.Authors.ToListAsync();
        }

        /// <summary>
        /// Determines if a given author code is currently in-use.
        /// </summary>
        /// <param name="authorCode">the author code related to an author.</param>
        /// <returns><c>true</c>if the author code exists, otherwise <c>false</c>.</returns>
        public bool IsAuthorCodeInUse(string authorCode)
        {
            if (string.IsNullOrWhiteSpace(authorCode))
            {
                throw new ArgumentException("Author code cannot be null or empty.", nameof(authorCode));
            }

            return DbContext.Authors.Any(x => x.AuthorCode == authorCode);
        }

        /// <summary>
        /// Determines if a given author id matches an author in the repository.
        /// </summary>
        /// <param name="authorId">the unique identifier for an author</param>
        /// <returns><c>true</c>if the author id exists for an author, otherwise <c>false</c>.</returns>
        public bool IsAuthorValid(int authorId)
        {
            return DbContext.Authors.Any(a => a.Id == authorId);
        }

        /// <summary>
        /// Returns an author and all book titles that are associated with the author.
        /// </summary>
        /// <param name="authorId">the unique identifer for an author.</param>
        /// <returns></returns>
        public Task<List<AuthorTitle>> GetTitlesForAuthorAsync(int authorId)
        {
            return DbContext.AuthorTitles
                .Include(a => a.Author)
                .Include(b => b.Title)
                .Where(x => x.AuthorId == authorId)
                .ToListAsync();
        }
    }
}
