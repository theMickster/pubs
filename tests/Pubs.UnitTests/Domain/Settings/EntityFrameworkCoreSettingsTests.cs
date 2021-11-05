using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Settings;
using System.Collections.Generic;
using Xunit;

namespace Pubs.UnitTests.Domain.Settings
{
    public class EntityFrameworkCoreSettingsTests
    {
        [Fact]
        public void property_update_succeeds()
        {
            var sut = new EntityFrameworkCoreSettings()
            {
                CommandLogLevel = "Debug",
                ComamndTimeout = 1254,
                CurrentConnectionStringName = "HelloWorld",
                DatabaseConnectionStrings = new List<DatabaseConnectionString>() { new DatabaseConnectionString() {ConnectionStringName = "HelloWorld" } }
            };

            using(new AssertionScope())
            {
                sut.CommandLogLevel.Should().Be("Debug");
                sut.ComamndTimeout.Should().Be(1254);
                sut.CurrentConnectionStringName.Should().Be("HelloWorld");
                sut.DatabaseConnectionStrings.Count.Should().Be(1);
            }


        }
    }
}
