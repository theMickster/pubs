using System;
using System.Linq;
using FluentAssertions;
using Pubs.SharedKernel.Constants;
using Pubs.UnitTests.Setup;
using Xunit;

namespace Pubs.UnitTests.SharedKernel.Constants
{
    public class RouteNamesTests : UnitTestBase
    {
        public Type SutType => typeof(RouteNames);

        [Fact]
        public void type_has_correct_members()
        {
            var members = SutType.GetMembers().ToList();

            members.Count(x => x.Name == "Home").Should().Be(1);
            members.Count(x => x.Name == "Privacy").Should().Be(1);
            members.Count(x => x.Name == "Login").Should().Be(1);
            members.Count(x => x.Name == "Logout").Should().Be(1);
            members.Count(x => x.Name == "LoginFailure").Should().Be(1);
            members.Count(x => x.Name == "Error").Should().Be(1);
        }

        [Fact]
        public void type_members_are_correct()
        {
            RouteNames.Home.Should().Be("Home");
            RouteNames.Privacy.Should().Be("Privacy");
            RouteNames.Login.Should().Be("Login");
            RouteNames.Logout.Should().Be("Logout");
            RouteNames.LoginFailure.Should().Be("LoginFailure");
            RouteNames.Error.Should().Be("Error");
        }
    }
}
