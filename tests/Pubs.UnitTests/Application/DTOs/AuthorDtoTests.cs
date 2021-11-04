using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.Application.DTOs;
using Xunit;

namespace Pubs.UnitTests.Application.DTOs
{
    public class AuthorDtoTests
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new AuthorDto()
            {
                Id = 1,
                AuthorCode = "ABC",
                Name = "Unit Tests",
                PhoneNumber = "303-333-4455",
                Address = "Address 001",
                City = "Denver",
                State = "CO",
                ZipCode = "80018",
                Contract = true
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(1);
                sut.Name.Should().Be("Unit Tests");
                sut.AuthorCode.Should().Be("ABC");
                sut.PhoneNumber.Should().Be("303-333-4455");
                sut.Address.Should().Be("Address 001");
                sut.City.Should().Be("Denver");
                sut.State.Should().Be("CO");
                sut.ZipCode.Should().Be("80018");
                sut.Contract.Should().BeTrue();
            }
        }
    }
}
