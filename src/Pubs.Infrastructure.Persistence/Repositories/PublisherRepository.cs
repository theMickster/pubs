using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class PublisherRepository : EntityFrameworkRepository<Publisher, int>, IPublisherRepository
    {
        public PublisherRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}