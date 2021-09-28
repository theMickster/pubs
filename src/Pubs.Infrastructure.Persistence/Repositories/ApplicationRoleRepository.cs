using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.DbContexts;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class ApplicationRoleRepository : EntityFrameworkRepository<ApplicationRole, int>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(PubsContext dbContext) : base(dbContext)
        {
        }
    }
}
