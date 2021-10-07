using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class AuthorTitleTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new AuthorTitle
            {
                Id = 25,                
                TitleId = 17,
                TitleCode = "TC01",                
                AuthorOrder = 1,
                Royalty = 18,
                AuthorCode = "ABC123456",
                AuthorId = 757,
                Author = new Author() {  Id = 757},
                Title = new Title() { Id = 17 }
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(25);
                sut.TitleId.Should().Be(17);
                sut.TitleCode.Should().Be("TC01");
                sut.AuthorOrder.Should().Be(1);
                sut.Royalty.Should().Be(18);
                sut.AuthorCode.Should().Be("ABC123456");
                sut.AuthorId.Should().Be(757);
                sut.AuthorCode.Should().Be("ABC123456");
                sut.Author.Id.Should().Be(757);
                sut.Title.Id.Should().Be(17);
            }
        }
    }
}
