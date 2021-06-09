using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.Domain.Entities
{
    public class SaleTests : UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new Sale
            {
                Id = 1548,
                OrderNumber = "ABC-XYZ123",
                OrderDate = TestRunDate,
                Quantity = 10,
                PaymentTerms = "Net-15",
                StoreId = 25,
                StoreCode = "AMZ514",
                Store = new Store { Id = 25, StoreCode = "AMZ514"},
                TitleCode = "123456",
                TitleId = 8489,
                Title = new Title { Id = 8489 }
            };

            using (new AssertionScope())
            {
                sut.Id.Should().Be(1548);
                sut.OrderNumber.Should().Be("ABC-XYZ123");
                sut.OrderDate.Should().Be(TestRunDate);
                sut.Quantity.Should().Be(10);
                sut.PaymentTerms.Should().Be("Net-15");
                sut.StoreId.Should().Be(25);
                sut.StoreCode.Should().Be("AMZ514");
                sut.Store.Id.Should().Be(25);
                sut.TitleCode.Should().Be("123456");
                sut.TitleId.Should().Be(8489);
                sut.Title.Id.Should().Be(8489);
            }
        }
    }
}
