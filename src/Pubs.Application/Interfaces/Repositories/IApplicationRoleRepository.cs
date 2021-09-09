using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Application.Interfaces.Repositories
{
    public interface IApplicationRoleRepository : IAsyncRepository<ApplicationRole, int>, IRepository<ApplicationRole, int>
    {
    }
}
