using System;
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
        public void property_update_first_constructor_succeeds()
        {
            var sut = new ApplicationUser(TestRunDate)
            {
                Id = 3,
                FirstName = "Unit",
                MiddleName = "J.",
                LastName = "Test",
                EmailAddress = "unit.j.test@something.com",
                UserName = "unit.j.test",
                UserPrincipalName = "1234567890123456@something.com",
                PhoneNumber = "3034445566",
                ApplicationUserRoles = new List<ApplicationUserRole> {new ApplicationUserRole{Id = 1002}}
            };

            sut.UpdateApplicationUserStatus(new ApplicationUserStatus { Id = 1001, StatusName = "Active", StatusAbbreviation = "A" });

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
                sut.ApplicationUserStatus.Id.Should().Be(1001);
                sut.ApplicationUserRoles.Should().NotBeNullOrEmpty();
                sut.ApplicationUserRoles.Count(x => x.Id == 1002).Should().Be(1);

                sut.LastSuccessfulLogin.Should().Be(TestRunDate);

                sut.IsActive.Should().BeTrue();
                sut.IsInactive.Should().BeFalse();
                sut.IsLocked.Should().BeFalse();
            }
        }

        [Fact]
        public void property_update_second_constructor_succeeds()
        {
            var sut = new ApplicationUser(TestRunDate, new ApplicationUserStatus { Id = 1002, StatusName = "Inactive", StatusAbbreviation = "I" })
            {
                Id = 3,
                FirstName = "Unit",
                MiddleName = "J.",
                LastName = "Test",
                EmailAddress = "unit.j.test@something.com",
                UserName = "unit.j.test",
                UserPrincipalName = "1234567890123456@something.com",
                PhoneNumber = "3034445566",
                ApplicationUserRoles = new List<ApplicationUserRole> { new ApplicationUserRole { Id = 1001 } }
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
                sut.ApplicationUserStatus.Id.Should().Be(1002);
                sut.ApplicationUserRoles.Should().NotBeNullOrEmpty();
                sut.ApplicationUserRoles.Count(x => x.Id == 1001).Should().Be(1);

                sut.LastSuccessfulLogin.Should().Be(TestRunDate);

                sut.IsActive.Should().BeFalse();
                sut.IsInactive.Should().BeTrue();
                sut.IsLocked.Should().BeFalse();
            }
        }

        [Fact]
        public void update_last_successful_login_succeeds()
        {
            var sut = new ApplicationUser(null)
            { 
                Id = 787
            };

            sut.UpdateLastSuccessfulLogin(TestRunDate.AddDays(-1));

            using (new AssertionScope())
            {
                sut.LastSuccessfulLogin.Should().NotBeNull();
                sut.LastSuccessfulLogin.Should().Be(TestRunDate.AddDays(-1));

                sut.UpdateLastSuccessfulLogin(TestRunDate.AddDays(1));

                sut.LastSuccessfulLogin.Should().NotBeNull();
                sut.LastSuccessfulLogin.Should().Be(TestRunDate.AddDays(1));
            }
        }

        [Fact]
        public void update_last_successful_throws_correct_exception()
        {
            var sut = new ApplicationUser(TestRunDate)
            {
                Id = 303
            };

            ((Action)(() => sut.UpdateLastSuccessfulLogin(TestRunDate.AddDays(-7))))
                .Should().Throw<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("The date parameter cannot be before the current value");

        }


    }
}
