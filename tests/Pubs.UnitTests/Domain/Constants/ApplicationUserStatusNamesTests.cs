using FluentAssertions;
using Pubs.CoreDomain.Constants;
using Pubs.UnitTests.Setup;
using System;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Domain.Constants
{
    public class ApplicationUserStatusNamesTests : UnitTestBase
    {
        public Type SutType => typeof(ApplicationUserStatusNames);

        [Fact]
        public void type_has_correct_members()
        {
            var members = SutType.GetMembers().ToList();

            members.Count(x => x.Name == "Active").Should().Be(1);
            members.Count(x => x.Name == "Inactive").Should().Be(1);
            members.Count(x => x.Name == "Locked").Should().Be(1);
        }

        [Fact]
        public void type_members_are_correct()
        {
            ApplicationUserStatusNames.Active.Should().Be("Active");
            ApplicationUserStatusNames.Inactive.Should().Be("Inactive");
            ApplicationUserStatusNames.Locked.Should().Be("Locked");
        }
    }
}
