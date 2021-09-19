using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : EntityFrameworkRepository<Sale, int>, ISaleRepository
    {
        public SaleRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}