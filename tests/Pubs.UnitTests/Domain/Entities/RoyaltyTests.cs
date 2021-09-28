using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class RoyaltyTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Royalty
            {
                Id = 3425,
                TitleId = 1789,
                RoyaltyAmount = 12,
                LowRange = 5,
                HighRange = 15,
                TitleCode = "ABC123456",
                Title = new Title {Id = 1789, TitleCode = "ABC123456"}
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(3425);
                sut.TitleId.Should().Be(1789);
                sut.RoyaltyAmount.Should().Be(12);
                sut.LowRange.Should().Be(5);
                sut.HighRange.Should().Be(15);
                sut.TitleCode.Should().Be("ABC123456");
                sut.Title.Should().NotBeNull();
                sut.Title.Id.Should().Be(1789);
            }
        }
    }
}
