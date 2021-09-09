using FluentAssertions;
using Pubs.CoreDomain.Enums;
using Pubs.UnitTests.Setup;
using System;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Domain.Enums
{
    public class ApplicationRoleEnumTests : UnitTestBase
    {
        public Type SutType => typeof(ApplicationRoleEnum);

        [Fact]
        public void enum_has_correct_members()
        {
            var members = SutType.GetMembers().ToList();

            members.Count(x => x.Name == "Administrator").Should().Be(1);
            members.Count(x => x.Name == "User").Should().Be(1);
            members.Count(x => x.Name == "ReadOnlyUser").Should().Be(1);
            members.Count(x => x.Name == "PowerUser").Should().Be(1);

            Enum.GetName(SutType, 1001).Should().Be("Administrator");
            Enum.GetName(SutType, 1002).Should().Be("User");
            Enum.GetName(SutType, 1003).Should().Be("ReadOnlyUser");
            Enum.GetName(SutType, 1004).Should().Be("PowerUser");
            Enum.GetName(SutType, 1005).Should().BeNull();
        }
    }
}
