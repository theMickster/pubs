using FluentAssertions;
using Pubs.CoreDomain.Enums;
using Pubs.UnitTests.Setup;
using System;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Domain.Enums
{
    public class ApplicationUserStatusAbbreviationEnumTests : UnitTestBase
    {
        public Type SutType => typeof(ApplicationUserStatusAbbreviationEnum);

        [Fact]
        public void enum_has_correct_members()
        {
            var members = SutType.GetMembers().ToList();

            members.Count(x => x.Name == "A").Should().Be(1);
            members.Count(x => x.Name == "I").Should().Be(1);
            members.Count(x => x.Name == "L").Should().Be(1);

            Enum.GetName(SutType, 1).Should().Be("A");
            Enum.GetName(SutType, 2).Should().Be("I");
            Enum.GetName(SutType, 3).Should().Be("L");
            Enum.GetName(SutType, 4).Should().BeNull();
        }
    }
}
