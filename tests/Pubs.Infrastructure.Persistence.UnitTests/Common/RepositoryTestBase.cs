using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.Infrastructure.Persistence.Unit.Tests.Factories;
using System;

namespace Pubs.Infrastructure.Persistence.Unit.Tests.Common
{
    public class RepositoryTestBase : IDisposable
    {
        protected readonly PubsContext _context;
        protected readonly PubsContextFactory _factory;

        public RepositoryTestBase()
        {
            _factory = new PubsContextFactory();
            _context = _factory.Create();

            AddJobs();
            AddPublishers();
            AddEmployees();
        }

        private void AddPublishers()
        {
            _context.Publishers.AddRange(
                new Publisher { Id = 1, PublisherName = "Random House", PublisherCode = "ABC-12345", City = "New York", State = "NY", ZipCode = "11111" }
                , new Publisher { Id = 2, PublisherName = "Simon & Schuster", PublisherCode = "DEF-67890", City = "New York", State = "NY", ZipCode = "11111" }
                , new Publisher { Id = 3, PublisherName = "HarperCollins ", PublisherCode = "GHI-1234", City = "Boston", State = "MA", ZipCode = "33333" }
                , new Publisher { Id = 4, PublisherName = "Scholastic", PublisherCode = "JKL-12345", City = "Boston", State = "MA", ZipCode = "33333" }
                , new Publisher { Id = 5, PublisherName = "Penguin Putnam", PublisherCode = "MNO-43210", City = "Los Angles", State = "CA", ZipCode = "44444" }
                , new Publisher { Id = 6, PublisherName = "Houghton Mifflin", PublisherCode = "PQR-56789", City = "Los Angles", State = "CA", ZipCode = "44444" }
            );

            _context.SaveChanges();
        }

        private void AddJobs()
        {
            _context.Jobs.AddRange(
                new Job { Id = 1, JobDescription = "CEO", MinimumLevel = 200, MaximumLevel = 250 }
                , new Job { Id = 2, JobDescription = "CFO", MinimumLevel = 175, MaximumLevel = 250 }
                , new Job { Id = 3, JobDescription = "CTO", MinimumLevel = 175, MaximumLevel = 225 }
                , new Job { Id = 4, JobDescription = "Publisher", MinimumLevel = 150, MaximumLevel = 200 }
                , new Job { Id = 5, JobDescription = "Editor", MinimumLevel = 100, MaximumLevel = 150 }
                , new Job { Id = 6, JobDescription = "Salesperson", MinimumLevel = 50, MaximumLevel = 125 }
            );

            _context.SaveChanges();
        }

        private void AddEmployees()
        {
            _context.Employees.AddRange(
                new Employee
                {
                    Id = 1,
                    EmployeeCode = "emp3508",
                    FirstName = "Joe",
                    MiddleName = "P",
                    LastName = "Jones",
                    JobId = 1,
                    JobLevel = 250,
                    PublisherId = 1,
                    PublisherCode = "ABC-12345",
                    HireDate = Convert.ToDateTime("01-10-1991")
                }
                , new Employee
                {
                    Id = 2,
                    EmployeeCode = "emp3509",
                    FirstName = "Frank",
                    MiddleName = "Z",
                    LastName = "Smith",
                    JobId = 2,
                    JobLevel = 225,
                    PublisherId = 1,
                    PublisherCode = "ABC-12345",
                    HireDate = Convert.ToDateTime("01-12-1991")
                }
                , new Employee
                {
                    Id = 3,
                    EmployeeCode = "emp3510",
                    FirstName = "Mike",
                    MiddleName = "B",
                    LastName = "Andrews",
                    JobId = 1,
                    JobLevel = 250,
                    PublisherId = 2,
                    PublisherCode = "DEF-67890",
                    HireDate = Convert.ToDateTime("02-10-1992")
                }
                , new Employee
                {
                    Id = 4,
                    EmployeeCode = "emp3511",
                    FirstName = "Terry",
                    MiddleName = "J",
                    LastName = "Clarke",
                    JobId = 2,
                    JobLevel = 225,
                    PublisherId = 2,
                    PublisherCode = "DEF-67890",
                    HireDate = Convert.ToDateTime("02-11-1992")
                }
            );

            _context.SaveChanges();
        }


        public void Dispose()
        {
            _factory.Destroy(_context);
        }
    }
}
