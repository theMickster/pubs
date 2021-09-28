using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.Application.DTOs;
using Xunit;

namespace Pubs.UnitTests.Application.DTOs
{
    public class AuthorUpdateContractDtoTests
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new AuthorUpdateContractDto()
            {
                AuthorId = 7,
                Contract = true
            };

            using (new AssertionScope())
            {
                sut.AuthorId.Should().Be(7);
                sut.Contract.Should().BeTrue();
            }
        }
    }
}
