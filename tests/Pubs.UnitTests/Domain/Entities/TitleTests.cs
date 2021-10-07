using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class TitleTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Title
            {
                Id = 10,
                TitleCode = "HGI981",
                Advance = 5000.00m,
                Notes = "Hello World",
                Price = 12.99m,
                PublishedDate = TestRunDate,
                PublisherId = 64,
                TitleType = "Business",
                PublisherCode = "AMZ987",
                Royalty = 2,
                YearToDateSales = 7851,
                TitleName = "Secrets of Silicon Valley",
                Publisher = new Publisher { Id = 4 },
                Royalties = new List<Royalty> { new Royalty { Id = 5 } },
                Sales = new List<Sale> { new Sale { Id = 546 } },
                AuthorTitles = new List<AuthorTitle>() { new AuthorTitle() { Id = 7} }

            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(10);
                sut.TitleCode.Should().Be("HGI981");
                sut.Advance.Should().Be(5000.00m);
                sut.Notes.Should().Be("Hello World");
                sut.Price.Should().Be(12.99m);
                sut.PublishedDate.Should().Be(TestRunDate);
                sut.PublisherId.Should().Be(64);
                sut.TitleType.Should().Be("Business");
                sut.PublisherCode.Should().Be("AMZ987");
                sut.Royalty.Should().Be(2);
                sut.YearToDateSales.Should().Be(7851);
                sut.TitleName.Should().Be("Secrets of Silicon Valley");
                sut.Publisher.Id.Should().Be(4);
                sut.Royalties.Should().NotBeNullOrEmpty();
                sut.Royalties.Count.Should().Be(1);
                sut.Sales.Should().NotBeNullOrEmpty();
                sut.Sales.Count.Should().Be(1);
                sut.AuthorTitles.FirstOrDefault(x => x.Id == 7).Should().NotBeNull();
            }
        }
    }
}
