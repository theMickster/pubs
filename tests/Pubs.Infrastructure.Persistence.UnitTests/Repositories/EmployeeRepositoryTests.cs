using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.Infrastructure.Persistence.Unit.Tests.Common;
using System;
using Xunit;

namespace Pubs.Infrastructure.Persistence.Unit.Tests.Repositories
{
    public class EmployeeRepositoryTests : RepositoryTestBase
    {
        public EmployeeRepositoryTests()
        {

        }
        
        [Fact]
        public void get_employee_list_async_returns_true()
        {
            // Arrange
            var sut = new EmployeeRepository(_context);

            // Act
            var employees = sut.GetEmployeesAsync().Result;

            // Assert
            Assert.Equal(4, employees.Count);

            foreach(var employee in employees)
            {
                Assert.NotNull(employee.Publisher);
            }
        }

        [Fact]
        public void get_employee_by_id_asyc_returns_true()
        {
            // Arrange
            var sut = new EmployeeRepository(_context);

            // Act
            var employee = sut.GetEmployeeAsync(id: 1).Result;

            // Assert
            Assert.Equal("Joe", employee.FirstName);
            Assert.Equal("Jones", employee.LastName);
            Assert.NotNull(employee.Job);
            Assert.NotNull(employee.Publisher);
        }

        [Fact]
        public void get_by_id_async_returns_true()
        {
            // Arrange
            var sut = new EmployeeRepository(_context);

            // Act
            var employee = sut.GetByIdAsync(id: 2).Result;

            // Assert
            Assert.Equal("Frank", employee.FirstName);
            Assert.Equal("Smith", employee.LastName);
            Assert.NotNull(employee.Job);
            Assert.NotNull(employee.Publisher);
        }

        [Fact]
        public void get_list_async_returns_true()
        {
            // Arrange
            var sut = new EmployeeRepository(_context);

            // Act
            var employees = sut.ListAllAsync().Result;

            // Assert
            Assert.Equal(4, employees.Count);

            foreach (var employee in employees)
            {
                Assert.NotNull(employee.Publisher);
                Assert.NotNull(employee.Job);
            }
        }

        [Fact]
        public void add_employee_async_returns_true()
        {
            // Arrange
            var sut = new EmployeeRepository(_context);

            // Act
            var addedEmployee = sut.AddAsync(
                new Employee{
                    EmployeeCode = "emp3512",
                    FirstName = "Pete",
                    MiddleName = "U",
                    LastName = "Olsen",
                    JobId = 6,
                    JobLevel = 50,
                    PublisherId = 6,
                    PublisherCode = "PQR-56789",
                    HireDate = Convert.ToDateTime("02-28-2016")
            }).Result;

            var retrievedEmployee = sut.GetEmployeeAsync(id: addedEmployee.Id).Result;

            // Assert
            Assert.NotNull(addedEmployee);
            Assert.Equal("emp3512", addedEmployee.EmployeeCode);
            Assert.Equal(retrievedEmployee.EmployeeCode, addedEmployee.EmployeeCode);
        }

        [Fact]
        public async void update_employee_async_returns_trueAsync()
        {
            // Arrange
            var sut = new EmployeeRepository(_context);

            // Act
            var addedEmployee = sut.AddAsync(
                new Employee
                {
                    EmployeeCode = "emp3515",
                    FirstName = "Matthh",
                    MiddleName = "D",
                    LastName = "Parker",
                    JobId = 4,
                    JobLevel = 50,
                    HireDate = Convert.ToDateTime("04-18-2016")
                }).Result;

            addedEmployee.PublisherId = 5;
            addedEmployee.FirstName = "Matt";
            await sut.UpdateAsync(addedEmployee);

            var retrievedEmployee = sut.GetEmployeeAsync(id: addedEmployee.Id).Result;

            // Assert
            Assert.NotNull(addedEmployee);
            Assert.NotNull(retrievedEmployee);
            Assert.Equal("emp3515", addedEmployee.EmployeeCode);
            Assert.Equal("Matt", retrievedEmployee.FirstName);
            Assert.Equal(retrievedEmployee.EmployeeCode, addedEmployee.EmployeeCode);
        }


    }
}

