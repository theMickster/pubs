using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.Application.DTOs;
using Xunit;

namespace Pubs.UnitTests.Application.DTOs
{
    public class AuthorUpdateDtoTests
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new AuthorUpdateDto()
            {
                AuthorId = 7, 
                FirstName = "Unit",
                LastName = "Test",
                PhoneNumber = "303-333-4455",
                Address = "12345 Unit Test",
                City = "Denver",
                State = "CO",
                ZipCode = "80014"
            };

            using (new AssertionScope())
            {
                sut.FirstName.Should().Be("Unit");
                sut.LastName.Should().Be("Test");
                sut.AuthorId.Should().Be(7);
                sut.PhoneNumber.Should().Be("303-333-4455");
                sut.Address.Should().Be("12345 Unit Test");
                sut.City.Should().Be("Denver");
                sut.State.Should().Be("CO");
                sut.ZipCode.Should().Be("80014");
            }
        }
    }
}
