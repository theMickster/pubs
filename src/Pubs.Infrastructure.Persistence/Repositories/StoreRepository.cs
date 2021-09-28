using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class StoreRepository : EntityFrameworkRepository<Store, int>, IStoreRepository
    {
        public StoreRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}