using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.Application.DTOs;
using Xunit;

namespace Pubs.UnitTests.Application.DTOs
{
    public class AuthorCreateDtoTests
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new AuthorCreateDto()
            {
                AuthorCode = "ABC",
                FirstName = "Unit",
                LastName = "Test",
                PhoneNumber = "303-333-4455"
            };

            using(new AssertionScope())
            {
                sut.FirstName.Should().Be("Unit");
                sut.LastName.Should().Be("Test");
                sut.AuthorCode.Should().Be("ABC");
                sut.PhoneNumber.Should().Be("303-333-4455");
            }
        }
    }
}
