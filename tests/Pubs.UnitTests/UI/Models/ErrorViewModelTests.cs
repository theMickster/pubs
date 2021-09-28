using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.UI.Models;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.UI.Models
{
    public class ErrorViewModelTests: UnitTestBase
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new ErrorViewModel()
            {
                RequestId = "ABC"
            };

            using (new AssertionScope())
            {
                sut.RequestId.Should().Be("ABC");
                sut.ShowRequestId.Should().BeTrue();

                sut.RequestId = null;
                sut.ShowRequestId.Should().BeFalse();
            }
        }
    }
}