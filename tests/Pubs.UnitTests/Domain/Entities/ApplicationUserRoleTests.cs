using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities.Security;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class ApplicationUserRoleTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new ApplicationUserRole
            {
                Id = 1,
                ApplicationRoleId = 1,
                ApplicationUserId = 3,
                ApplicationRole = new ApplicationRole
                {
                    Id = 2,
                    RoleName = "PowerUser"
                },
                ApplicationUser = new ApplicationUser(TestRunDate)
                {
                    Id = 3,
                    FirstName = "Unit",
                    MiddleName = "J.",
                    LastName = "Test",
                    EmailAddress = "unit.j.test@something.com",
                    UserName = "unit.j.test",
                    UserPrincipalName = "1234567890123456@something.com",
                    PhoneNumber = "3034445566"
                }
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(1);
                sut.ApplicationRoleId.Should().Be(1);
                sut.ApplicationUserId.Should().Be(3);

                sut.ApplicationRole.Should().NotBeNull();
                sut.ApplicationRole.Id.Should().Be(2);
                sut.ApplicationUser.Should().NotBeNull();
                sut.ApplicationUser.Id.Should().Be(3);

            }
        }
    }
}
