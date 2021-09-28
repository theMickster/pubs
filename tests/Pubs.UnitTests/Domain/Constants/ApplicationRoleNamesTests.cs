using FluentAssertions;
using Pubs.CoreDomain.Constants;
using Pubs.UnitTests.Setup;
using System;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Domain.Constants
{
    public class ApplicationRoleNamesTests : UnitTestBase
    {
        public Type SutType => typeof(ApplicationRoleNames);

        [Fact]
        public void type_has_correct_members()
        {
            var members = SutType.GetMembers().ToList();

            members.Count(x => x.Name == "Administrator").Should().Be(1);
            members.Count(x => x.Name == "User").Should().Be(1);
            members.Count(x => x.Name == "ReadOnlyUser").Should().Be(1);
            members.Count(x => x.Name == "PowerUser").Should().Be(1);
        }

        [Fact]
        public void type_members_are_correct()
        {
            ApplicationRoleNames.Administrator.Should().Be("Administrator");
            ApplicationRoleNames.User.Should().Be("User");
            ApplicationRoleNames.ReadOnlyUser.Should().Be("ReadOnlyUser");
            ApplicationRoleNames.PowerUser.Should().Be("PowerUser");
        }
    }
}
