using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class PublisherLogoTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new PublisherLogo
            {
                Id = 178,
                PublisherInfo = "This is sample text data for New Moon Books.",
                PublisherCode = "0736",
                Logo = new byte[256],
                Publisher = new Publisher { Id = 178}
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(178);
                sut.PublisherInfo.Should().Be("This is sample text data for New Moon Books.");
                sut.PublisherCode.Should().Be("0736");
                
                sut.Logo.Should().NotBeNull();
                sut.Publisher.Id.Should().Be(178);
            }
        }
    }
}
