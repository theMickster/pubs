using FluentAssertions;
using Pubs.CoreDomain.Constants;
using Pubs.UnitTests.Setup;
using System;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Domain.Constants
{
    public class ApplicationUserStatusAbbreviationsTests : UnitTestBase
    {
        public Type SutType => typeof(ApplicationUserStatusAbbreviations);

        [Fact]
        public void type_has_correct_members()
        {
            var members = SutType.GetMembers().ToList();

            members.Count(x => x.Name == "A").Should().Be(1);
            members.Count(x => x.Name == "I").Should().Be(1);
            members.Count(x => x.Name == "L").Should().Be(1);
        }

        [Fact]
        public void type_members_are_correct()
        {
            ApplicationUserStatusAbbreviations.A.Should().Be("A");
            ApplicationUserStatusAbbreviations.I.Should().Be("I");
            ApplicationUserStatusAbbreviations.L.Should().Be("L");
        }
    }
}
