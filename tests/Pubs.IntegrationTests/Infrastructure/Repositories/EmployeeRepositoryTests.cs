using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.IntegrationTests.Setup;
using Xunit;

namespace Pubs.IntegrationTests.Infrastructure.Repositories
{
    public class EmployeeRepositoryTests : IntegrationTestBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeeRepositoryTests()
        {
            _repository = new EmployeeRepository(Context);
        }

        [Fact]
        public void get_employee_list_async_returns_true()
        {
            var employees = _repository.GetEmployeesAsync().Result;

            using (new AssertionScope())
            {
                employees.Should().NotBeNullOrEmpty();
            }

        }

        [Fact]
        public void get_employee_by_id_asyc_returns_true()
        {
            var employee = _repository.GetEmployeeAsync(id: 1).Result;

            using (new AssertionScope())
            {
                employee.Should().NotBeNull();
            }
        }

        [Fact]
        public void get_by_id_async_returns_true()
        {
            var employee = _repository.GetByIdAsync(id: 2).Result;

            using (new AssertionScope())
            {
                employee.Should().NotBeNull();
            }
        }

        [Fact]
        public void get_list_async_returns_true()
        {
            var employees = _repository.ListAllAsync().Result;

            using (new AssertionScope())
            {
                employees.Should().NotBeNullOrEmpty();
            }
        }


    }
}

