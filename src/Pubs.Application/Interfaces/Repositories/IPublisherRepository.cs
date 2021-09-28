using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.CoreDomain.Entities;

namespace Pubs.Application.Interfaces.Repositories
{
    public interface IPublisherRepository : IAsyncRepository<Publisher, int>
    {
    }
}