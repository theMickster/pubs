using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class DiscountRepository : EntityFrameworkRepository<Discount, int>, IDiscountRepository
    {
        public DiscountRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}