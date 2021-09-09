using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class PublisherLogoRepository : EntityFrameworkRepository<PublisherLogo, int>, IPublisherLogoRepository
    {
        public PublisherLogoRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}