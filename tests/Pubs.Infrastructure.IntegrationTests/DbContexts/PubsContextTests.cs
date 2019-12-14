using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.Application.Common.Helpers;
using System;
using System.Linq;
using Xunit;
using Pubs.CoreDomain.Entities;

namespace Pubs.Infrastructure.IntegrationTests.DbContexts
{
    public class PubsContextTests : IDisposable
    {
        private readonly PubsContext _context;

        public PubsContextTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

            var defaultSchema = new DbContextSchemaHelper(configuration["DefaultSchema"]);

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<PubsContext>();

            builder.UseSqlServer(connectionString)
                .UseInternalServiceProvider(serviceProvider);

            _context = new PubsContext(builder.Options, defaultSchema);

        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        [Fact]
        public void retrieving_authors_from_database_succeeds()
        {
            //Arrange + Act (not really acting on the authors list).
            var author = _context.Authors.Where(a => a.Id == 1).ToList();

            //Assert
            Assert.NotNull(author);
            Assert.Single(author);
            Assert.Equal("Bennet", author.Single()?.LastName);
        }

        [Fact]
        public void retrieving_authors_with_dummy_data_succeeds()
        {
            //Arrange
            var author = _context.Authors.Where(a => a.City == "Dummy Data");

            //Act
            var data = author.ToList();

            Assert.NotNull(data);
            Assert.Empty(data);
        }

        [Fact]
        public void add_job_publisher_and_employee_to_database_succeeds()
        {
            // Arrange
            var jobDescription = "IntegrationTestJob";
            var publisherName = "IntegrationTestPublisher";
            var publisherCode = "9989";
            var employeeCode = "emp11111F";

            var job = new Job { JobDescription = jobDescription, MinimumLevel = 200, MaximumLevel = 250 };
            var publuisher = new Publisher { PublisherName = publisherName, PublisherCode = publisherCode, City = "Aurora", State = "CO", ZipCode = "88888" };
            var employee = new Employee {
                EmployeeCode = employeeCode,
                FirstName = "Integration",
                MiddleName = "IT",
                LastName = "Test",
                JobLevel = 250,
                PublisherCode = publisherCode,
                HireDate = DateTime.Now
            };

            // Act
            _context.Publishers.Add(publuisher);
            _context.Jobs.Add(job);
            _context.SaveChanges();

            var newJob = _context.Jobs.FirstOrDefault(j => j.JobDescription == jobDescription);
            var newPublisher = _context.Publishers.FirstOrDefault(p => p.PublisherName == publisherName);

            employee.JobId = newJob.Id;
            employee.PublisherId = newPublisher.Id;
            _context.Employees.Add(employee);
            _context.SaveChanges();

            var newEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeCode == employeeCode);

            // Assert
            Assert.NotNull(newEmployee);
            Assert.NotNull(newEmployee.Publisher);
            Assert.NotNull(newEmployee.Job);
            Assert.Equal(job.JobDescription, newJob.JobDescription);
            Assert.Equal(publuisher.PublisherName, newPublisher.PublisherName);

            // Clean-up
            _context.Employees.Remove(newEmployee);
            _context.Jobs.Remove(newJob);
            _context.Publishers.Remove(newPublisher);
            _context.SaveChanges();
        }


        
    }
}
