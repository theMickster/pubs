using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class AuthorTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Author
            {
                Id = 25,
                FirstName = "Unit",
                LastName = "Test",
                AuthorCode = "ABC123456",
                Address = "123 Sesame St.",
                City = "Denver",
                State = "CO",
                ZipCode = "80123",
                PhoneNumber = "3038876688",
                Contract = true,
                AuthorTitles = new List<AuthorTitle>() { new AuthorTitle() { Id = 7 } }
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(25);
                sut.FirstName.Should().Be("Unit");
                sut.LastName.Should().Be("Test");
                sut.AuthorCode.Should().Be("ABC123456");
                sut.Address.Should().Be("123 Sesame St.");
                sut.City.Should().Be("Denver");
                sut.State.Should().Be("CO");
                sut.ZipCode.Should().Be("80123");
                sut.PhoneNumber.Should().Be("3038876688");
                sut.Contract.Should().BeTrue();
                sut.AuthorTitles.FirstOrDefault(x => x.Id == 7).Should().NotBeNull();
            }
        }
    }
}
