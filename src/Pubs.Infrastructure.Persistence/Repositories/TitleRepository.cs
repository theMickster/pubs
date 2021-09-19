using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class TitleRepository : EntityFrameworkRepository<Title, int>, ITitleRepository
    {
        public TitleRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}