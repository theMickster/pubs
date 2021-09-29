using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using System;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class EmployeeTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Employee
            {
                Id = 9,
                FirstName = "Unit",
                MiddleName = "J.",
                LastName = "Test",
                EmployeeCode = "ABC-1234",
                HireDate = new DateTime(2020, 12, 15),
                JobId = 12,
                JobLevel = 2,
                PublisherCode = "123",
                PublisherId = 16,
                Job = new Job() {Id = 12 },
                Publisher = new Publisher { Id = 16 }
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(9);
                sut.FirstName.Should().Be("Unit");
                sut.MiddleName.Should().Be("J.");
                sut.LastName.Should().Be("Test");
                sut.EmployeeCode.Should().Be("ABC-1234");
                sut.HireDate.Should().Be(new DateTime(2020, 12, 15));
                sut.JobId.Should().Be(12);
                sut.JobLevel.Should().Be(2);
                sut.PublisherCode.Should().Be("123");
                sut.PublisherId.Should().Be(16);
                sut.Job.Id.Should().Be(12);
                sut.Publisher.Id.Should().Be(16);
            }
        }
    }
}
