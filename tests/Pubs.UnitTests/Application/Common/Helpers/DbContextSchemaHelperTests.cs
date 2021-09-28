using FluentAssertions;
using Pubs.Application.Common.Helpers;
using System;
using Xunit;

namespace Pubs.UnitTests.Application.Common.Helpers
{
    public class DbContextSchemaHelperTests
    {
        [Fact]
        public void constructor_throws_correct_exception()
        {            
        ((Action)(() => new DbContextSchemaHelper(null)))
            .Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("schema");
        }

        [Fact]
        public void property_update_succeeds()
        {
            var sut = new DbContextSchemaHelper("common");
            sut.DefaultSchema.Should().Be("common");
        }
    }
}
