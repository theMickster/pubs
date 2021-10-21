using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Settings;
using System;
using Xunit;

namespace Pubs.UnitTests.Domain.Settings
{
    public class DatabaseConnectionStringTests
    {
        [Fact]
        public void property_update_succeeds()
        {
            var connectionString = "Server=(local); Database=HelloWorld; Application Name=Only the Best Will Do;";
            var sut = new DatabaseConnectionString();
            sut.ConnectionStringName = "MyDefaultConnectionStringName";

            using (new AssertionScope())
            {
                sut.ConnectionStringName.Should().Be("MyDefaultConnectionStringName");
                sut.ConnectionString.Should().Be("Server=(local); Database=HelloWorld; Application Name=TestTestTest;", "because we expect this to be the default connection string name");
                sut.ConnectionString = connectionString;
                sut.ConnectionString.Should().Be("Server=(local); Database=HelloWorld; Application Name=Only the Best Will Do;", "because the new connection string is valid");
            }
        }

        [Fact]
        public void property_update_throws_correct_exceptions()
        {
            var sut = new DatabaseConnectionString();

            using(new AssertionScope())
            {
                sut.ConnectionString.Should().Be("Server=(local); Database=HelloWorld; Application Name=TestTestTest;", "because we expect this to be the default connection string name");

                ((Action)(() => sut.ConnectionString = "")).Should().Throw<Exception>()
                    .And.Message.Should().Contain("The connection string cannot be null or empty");

                ((Action)(() => sut.ConnectionString = null)).Should().Throw<Exception>()
                    .And.Message.Should().Contain("The connection string cannot be null or empty");

                ((Action)(() => sut.ConnectionString = "       ")).Should().Throw<Exception>()
                    .And.Message.Should().Contain("The connection string cannot be null or empty");

                ((Action)(() => sut.ConnectionString = "Database=HelloWorld; Application Name=Only the Best Will Do;")).Should().Throw<Exception>()
                    .And.Message.Should().Contain("The connection string must contain a 'Server' attribute.");

                ((Action)(() => sut.ConnectionString = "Server=(local); Application Name=Only the Best Will Do;")).Should().Throw<Exception>()
                    .And.Message.Should().Contain("The connection string must contain a 'database' or 'initial catalog' attribute.");

                ((Action)(() => sut.ConnectionString = "Server=(local); Database=HelloWorld; ")).Should().Throw<Exception>()
                    .And.Message.Should().Contain("The connection string must contain a 'application name' attribute to distinguish it from other database connections.");

            }
        }
    }
}
