using Pubs.CoreDomain.Entities.Security;
using Pubs.UnitTests.Setup;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class ApplicationRoleTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new ApplicationRole
            {
                Id = 1001,
                RoleName = "Admin",
                ApplicationUserRoles = new List<ApplicationUserRole>
                {
                    new ApplicationUserRole
                    {
                        Id = 10001,
                        ApplicationUserId = 7007,
                        ApplicationRoleId = 1001
                    }
                }
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(1001);
                sut.RoleName.Should().Be("Admin");
                sut.ApplicationUserRoles.Count.Should().Be(1);
                sut.ApplicationUserRoles.Count(x => x.Id == 10001).Should().Be(1);
            }
        }
    }
}
