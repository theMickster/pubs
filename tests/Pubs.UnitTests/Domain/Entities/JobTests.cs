using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class JobTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Job
            {
                Id = 1,
                JobDescription = "Publisher",
                MinimumLevel = 150,
                MaximumLevel = 250,
                Employees = new List<Employee> {new Employee {Id = 1, EmployeeCode = "ABC"}}
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(1);
                sut.JobDescription.Should().Be("Publisher");
                sut.MinimumLevel.Should().Be(150);
                sut.MaximumLevel.Should().Be(250);
                sut.Employees.Count.Should().Be(1);
                sut.Employees.FirstOrDefault(x => x.Id == 1).Should().NotBeNull();
            }

        }
    }
}
