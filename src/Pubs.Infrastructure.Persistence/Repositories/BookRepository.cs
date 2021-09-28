using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class BookRepository : EntityFrameworkRepository<Book, int>, IBookRepository
    {
        public BookRepository(PubsContext dbContext) : base(dbContext)
        {

        }

    }
}
