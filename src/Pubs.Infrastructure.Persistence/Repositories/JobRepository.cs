using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class JobRepository : EntityFrameworkRepository<Job, int>, IJobRepository
    {
        public JobRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}