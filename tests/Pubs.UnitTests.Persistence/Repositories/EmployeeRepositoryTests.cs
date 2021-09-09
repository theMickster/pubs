using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.SharedKernel.Tests.Constants;
using Pubs.UnitTests.Persistence.Setup;
using Pubs.UnitTests.Persistence.Setup.Fixtures;
using Xunit;

namespace Pubs.UnitTests.Persistence.Repositories
{
    [Collection(FixtureCollections.PubsInMemoryRepositoryCollection)]
    public class EmployeeRepositoryTests : PersistenceUnitTestBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeeRepositoryTests(PubsContextInMemoryDatabaseFixture fixture)
        {
            _repository = new EmployeeRepository(fixture.PubsDbContext);
        }

        /// <summary>
        /// Unit test to cover synchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void crud_process_succeeds()
        {
            var employee = new Employee
            {
                Id = 99999
                ,FirstName = "Unit"
                ,MiddleName = "T."
                ,LastName = "Test"
                ,JobId = 11
                ,EmployeeCode = "POK93028M"
                ,JobLevel = 85
                ,PublisherId = 1
                ,HireDate = TestRunDate
            };

            var savedEmployee = _repository.Add(employee);
            var updatedEmployee = _repository.GetById(savedEmployee.Id);

            using (new AssertionScope())
            {
                savedEmployee.Should().NotBeNull();
                savedEmployee.Id.Should().Be(99999);
                savedEmployee.FirstName.Should().Be("Unit");
                updatedEmployee.Id.Should().Be(savedEmployee.Id);

                updatedEmployee.FirstName = "UnitUnit";
                _repository.Update(updatedEmployee);
                
                updatedEmployee = _repository.GetById(savedEmployee.Id);
                updatedEmployee.FirstName.Should().Be("UnitUnit");

                _repository.Delete(updatedEmployee);
                _repository.GetById(savedEmployee.Id).Should().BeNull();
            }


        }

        /// <summary>
        /// Unit test to cover asynchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void async_crud_process_succeeds()
        {

            var employee = new Employee
            {
                Id = 77777
                ,FirstName = "Unit"
                ,MiddleName = "T."
                ,LastName = "Test"
                ,JobId = 11
                ,EmployeeCode = "POK93028M"
                ,JobLevel = 85
                ,PublisherId = 1
                ,HireDate = TestRunDate
            };

            var savedEmployee = _repository.AddAsync(employee).Result;
            var updatedEmployee = _repository.GetByIdAsync(savedEmployee.Id).Result;

            using (new AssertionScope())
            {
                savedEmployee.Should().NotBeNull();
                savedEmployee.Id.Should().Be(77777);
                savedEmployee.FirstName.Should().Be("Unit");
                updatedEmployee.Id.Should().Be(savedEmployee.Id);

                updatedEmployee.FirstName = "UnitUnit";
                _ = _repository.UpdateAsync(updatedEmployee);

                updatedEmployee = _repository.GetByIdAsync(savedEmployee.Id).Result;
                updatedEmployee.FirstName.Should().Be("UnitUnit");

                _ = _repository.DeleteAsync(updatedEmployee);
                _repository.GetByIdAsync(savedEmployee.Id).Result.Should().BeNull();
            }

        }

    }
}
