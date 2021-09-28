using Microsoft.EntityFrameworkCore;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pubs.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : EntityFrameworkRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(PubsContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await DbContext.Employees
                .Include(p => p.Publisher)
                .Include(a => a.Job)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await DbContext.Employees
                .Include(p => p.Publisher)
                .Include(a => a.Job)
                .FirstOrDefaultAsync(e => e.Id == id);
        }


    }
}
