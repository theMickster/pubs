using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities.Security;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class ApplicationUserStatusTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new ApplicationUserStatus()
            {
                Id = 7,
                StatusAbbreviation = "A",
                StatusName = "Active"
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(7);
                sut.StatusAbbreviation.Should().Be("A");
                sut.StatusName.Should().Be("Active");
            }
        }
    }
}
