using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.SharedKernel.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.SharedKernel.Entities
{
    public class BaseEntityTests : UnitTestBase
    {
        [Fact]
        public void base_entity_members_are_correct()
        {
            var sut = new MyEntity();
            sut.Id = 725634;

            using (new AssertionScope())
            {
                sut.Id.Should().Be(725634);
                sut.GetHashCode().Should().BeGreaterThan(0);
                sut.Validate(null).Should().BeEmpty();
            }
        }

        private class MyEntity : BaseEntity
        {

        }
    }
}
