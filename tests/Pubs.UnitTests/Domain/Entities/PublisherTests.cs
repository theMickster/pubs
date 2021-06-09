using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using System.Collections.Generic;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class PublisherTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Publisher
            {
                Id = 34,
                PublisherCode = "ABC",
                PublisherName = "ABC Publishing",
                City = "Las Vegas",
                State = "NV",
                ZipCode = "88021",
                Country = "USA",
                Books = new List<Book> { new Book{ Id = 1001 }},
                Employees = new List<Employee> { new Employee { Id=25, FirstName = "Sam", LastName = "Smith"}},
                Titles = new List<Title> { new Title {Id = 1548, PublisherId = 34} },
                PublisherLogos = new List<PublisherLogo> { new PublisherLogo{Id = 56, PublisherCode = "ABC" }}
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(34);
                sut.PublisherCode.Should().Be("ABC");
                sut.PublisherName.Should().Be("ABC Publishing");
                sut.City.Should().Be("Las Vegas");
                sut.State.Should().Be("NV");
                sut.ZipCode.Should().Be("88021");
                sut.Country.Should().Be("USA");

                sut.Books.Should().NotBeNullOrEmpty();

                sut.Employees.Should().NotBeNullOrEmpty();

                sut.Titles.Should().NotBeNullOrEmpty();

                sut.PublisherLogos.Should().NotBeNullOrEmpty();
            }
        }
    }
}
