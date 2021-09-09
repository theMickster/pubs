using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class RoyaltyRepository : EntityFrameworkRepository<Royalty, int>, IRoyaltyRepository
    {
        public RoyaltyRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}