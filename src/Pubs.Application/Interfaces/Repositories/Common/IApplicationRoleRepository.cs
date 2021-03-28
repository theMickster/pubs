using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Application.Interfaces.Repositories.Common
{
    public interface IApplicationRoleRepository : IAsyncRepository<ApplicationRole, int>, IRepository<ApplicationRole, int>
    {
    }
}
