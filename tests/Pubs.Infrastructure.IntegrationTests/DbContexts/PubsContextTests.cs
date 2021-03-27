using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Constants;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.IntegrationTests.Setup;
using System;
using System.Linq;
using Xunit;

namespace Pubs.Infrastructure.IntegrationTests.DbContexts
{
    public class PubsContextTests : IntegrationTestBase
    {
        [Fact]
        public void retrieving_authors_from_database_succeeds()
        {
            var author = Context.Authors.Where(a => a.Id == 1).ToList();

            Assert.NotNull(author);
            Assert.Single(author);
            Assert.Equal("Bennet", author.Single()?.LastName);
        }

        [Fact]
        public void retrieving_authors_with_dummy_data_succeeds()
        {
            var author = Context.Authors.Where(a => a.City == "Dummy Data");

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
            Context.Publishers.Add(publuisher);
            Context.Jobs.Add(job);
            Context.SaveChanges();

            var newJob = Context.Jobs.FirstOrDefault(j => j.JobDescription == jobDescription);
            var newPublisher = Context.Publishers.FirstOrDefault(p => p.PublisherName == publisherName);

            employee.JobId = newJob.Id;
            employee.PublisherId = newPublisher.Id;
            Context.Employees.Add(employee);
            Context.SaveChanges();

            var newEmployee = Context.Employees.FirstOrDefault(e => e.EmployeeCode == employeeCode);

            // Assert
            Assert.NotNull(newEmployee);
            Assert.NotNull(newEmployee.Publisher);
            Assert.NotNull(newEmployee.Job);
            Assert.Equal(job.JobDescription, newJob.JobDescription);
            Assert.Equal(publuisher.PublisherName, newPublisher.PublisherName);

            // Clean-up
            Context.Employees.Remove(newEmployee);
            Context.Jobs.Remove(newJob);
            Context.Publishers.Remove(newPublisher);
            Context.SaveChanges();
        }

        [Fact]
        public void application_roles_have_correct_values_succeeds()
        {
            const int totalCount = 4;
            var results = Context.ApplicationRoles.ToList();

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();

                results.Count().Should().Be(totalCount, "because we have [0] application roles.", totalCount);

                results.Count(x => x.RoleName == ApplicationRoleNames.Administrator).Should().Be(1);
                results.Count(x => x.RoleName == ApplicationRoleNames.PowerUser).Should().Be(1);
                results.Count(x => x.RoleName == ApplicationRoleNames.User).Should().Be(1);
                results.Count(x => x.RoleName == ApplicationRoleNames.ReadOnlyUser).Should().Be(1);
            }
        }

        [Fact]
        public void application_user_statuses_have_correct_values_succeeds()
        {
            const int totalCount = 3;
            var results = Context.ApplicationUserStatuses.ToList();

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();

                results.Count().Should().Be(totalCount, "because we have [0] application user statuses.", totalCount);

                results.Count(x => x.StatusName == ApplicationUserStatusNames.Active).Should().Be(1);
                results.Count(x => x.StatusName == ApplicationUserStatusNames.Inactive).Should().Be(1);
                results.Count(x => x.StatusName == ApplicationUserStatusNames.Locked).Should().Be(1);
            }

        }

    }
}
