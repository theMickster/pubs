using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.DbContexts;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class ApplicationUserStatusRepository : EntityFrameworkRepository<ApplicationUserStatus, int>, IApplicationUserStatusRepository
    {
        public ApplicationUserStatusRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}