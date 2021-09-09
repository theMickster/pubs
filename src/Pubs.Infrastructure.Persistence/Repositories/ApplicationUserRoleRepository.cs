using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.DbContexts;


namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class ApplicationUserRoleRepository : EntityFrameworkRepository<ApplicationUserRole, int>, IApplicationUserRoleRepository
    {
        public ApplicationUserRoleRepository(PubsContext dbContext) : base(dbContext)
        {

        }
    }
}