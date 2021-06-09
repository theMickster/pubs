using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities.Security;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class ApplicationUserTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new ApplicationUser(1, TestRunDate)
            {
                Id = 3,
                FirstName = "Unit",
                MiddleName = "J.",
                LastName = "Test",
                EmailAddress = "unit.j.test@something.com",
                UserName = "unit.j.test",
                UserPrincipalName = "1234567890123456@something.com",
                PhoneNumber = "3034445566",
                ApplicationUserStatus = new ApplicationUserStatus {Id = 1, StatusName = "Active", StatusAbbreviation = "A"},
                ApplicationUserRoles = new List<ApplicationUserRole> {new ApplicationUserRole{Id = 17}}
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(3);
                sut.FirstName.Should().Be("Unit");
                sut.MiddleName.Should().Be("J.");
                sut.LastName.Should().Be("Test");
                sut.EmailAddress.Should().Be("unit.j.test@something.com");
                sut.UserName.Should().Be("unit.j.test");
                sut.UserPrincipalName.Should().Be("1234567890123456@something.com");
                sut.PhoneNumber.Should().Be("3034445566");

                sut.ApplicationUserStatus.Should().NotBeNull();
                sut.ApplicationUserStatus.Id.Should().Be(1);
                sut.ApplicationUserRoles.Should().NotBeNullOrEmpty();
                sut.ApplicationUserRoles.Count(x => x.Id == 17).Should().Be(1);
            }
        }
    }
}
