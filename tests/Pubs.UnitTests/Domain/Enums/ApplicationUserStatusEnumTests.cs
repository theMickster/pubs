using FluentAssertions;
using Pubs.CoreDomain.Enums;
using Pubs.UnitTests.Setup;
using System;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Domain.Enums
{
    public class ApplicationUserStatusEnumTests : UnitTestBase
    {
        public Type SutType => typeof(ApplicationUserStatusEnum);

        [Fact]
        public void enum_has_correct_members()
        {
            var members = SutType.GetMembers().ToList();

            members.Count(x => x.Name == "Active").Should().Be(1);
            members.Count(x => x.Name == "Inactive").Should().Be(1);
            members.Count(x => x.Name == "Locked").Should().Be(1);

            Enum.GetName(SutType, 1001).Should().Be("Active");
            Enum.GetName(SutType, 1002).Should().Be("Inactive");
            Enum.GetName(SutType, 1003).Should().Be("Locked");
            Enum.GetName(SutType, 1004).Should().BeNull();
        }
    }
}
