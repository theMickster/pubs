using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class BookTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Book
            {
                Id = 9,
                AuthorCode = "UnitTest001",
                AuthorId = 17,
                AuthorOrder = 12,
                TitleId = 35,
                TitleCode = "ABC",
                Royalty = 54,
                Author = new Author {Id = 17},
                Publisher = new Publisher {Id=16}
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(9);
                sut.AuthorCode.Should().Be("UnitTest001");
                sut.AuthorId.Should().Be(17);
                sut.AuthorOrder.Should().Be(12);
                sut.TitleId.Should().Be(35);
                sut.TitleCode.Should().Be("ABC");
                sut.Royalty.Should().Be(54);
                sut.Author.Id.Should().Be(17);
                sut.Publisher.Id.Should().Be(16);
            }
        }
    }
}
