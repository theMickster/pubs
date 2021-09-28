using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class DiscountTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Discount
            {
                Id = 1,
                DiscountAmount = 5.00m,
                DiscountType = "Initial Customer",
                StoreCode = "7067",
                StoreId = 2,
                Store = new Store { Id = 2 },
                LowQuantity = 0,
                HighQuantity = 1000
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(1);
                sut.DiscountAmount.Should().Be(5.00m);
                sut.DiscountType.Should().Be("Initial Customer");
                sut.StoreCode.Should().Be("7067");
                sut.StoreId.Should().Be(2);
                sut.Store.Id.Should().Be(2 );
                sut.LowQuantity.Should().Be(0);
                sut.HighQuantity.Should().Be(1000);
            }
        }

    }
}
