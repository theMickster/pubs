using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.Application.DTOs;
using Xunit;

namespace Pubs.UnitTests.Application.DTOs
{
    public class AuthorUpdateAuthorCodeDtoTests
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new AuthorUpdateAuthorCodeDto()
            {
                AuthorId = 7,
                AuthorCode = "UnitTest"
            };

            using (new AssertionScope())
            {
                sut.AuthorId.Should().Be(7);
                sut.AuthorCode.Should().Be("UnitTest");
            }
        }
    }
}
