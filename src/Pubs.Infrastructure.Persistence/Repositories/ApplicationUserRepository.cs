using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class ApplicationUserRepository : EntityFrameworkRepository<ApplicationUser, int>, IApplicationUserRepository
    {
        public ApplicationUserRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}