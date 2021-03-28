using System.Collections.Generic;
using System.Threading.Tasks;
using Pubs.Application.Interfaces.Repositories.Common;
using Pubs.CoreDomain.Entities;

namespace Pubs.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IAsyncRepository<Employee, int>, IRepository<Employee, int>
    {
        Task<List<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeAsync(int id);

    }
}