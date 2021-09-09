using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Application.Interfaces.Repositories
{
    public interface IApplicationUserRoleRepository : IAsyncRepository<ApplicationUserRole, int>
    {
    }
}