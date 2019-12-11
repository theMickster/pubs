using Pubs.CoreDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pubs.Application.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeAsync(int id);

    }
}