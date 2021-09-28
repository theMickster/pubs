using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class StoreTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Store
            {
                Id = 34,
                StoreCode = "AMZ354",
                StoreAddress = "123 Main St.",
                City = "Seattle",
                State = "WA",
                ZipCode = "99856",
                StoreName = "Amazon #354",
                Discounts = new List<Discount> {new Discount { Id = 9} },
                Sales = new List<Sale> { new Sale { Id = 9 } }
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(34);
                sut.StoreCode.Should().Be("AMZ354");
                sut.StoreAddress.Should().Be("123 Main St.");
                sut.City.Should().Be("Seattle");
                sut.State.Should().Be("WA");
                sut.ZipCode.Should().Be("99856");
                sut.StoreName.Should().Be("Amazon #354");

                sut.Discounts.Should().NotBeNullOrEmpty();
                sut.Discounts.Count.Should().Be(1);
                sut.Sales.Should().NotBeNullOrEmpty();
                sut.Sales.Count.Should().Be(1);
            }
        }
    }
}
