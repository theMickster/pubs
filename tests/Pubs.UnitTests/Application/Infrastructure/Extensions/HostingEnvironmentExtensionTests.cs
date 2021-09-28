using FluentAssertions.Execution;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Xunit;
using Pubs.Application.Infrastructure.Extensions;
using HostingEnvironmentExtensions = Pubs.Application.Infrastructure.Extensions.HostingEnvironmentExtensions;
using FluentAssertions;

namespace Pubs.UnitTests.Application.Infrastructure.Extensions
{
    public class HostingEnvironmentExtensionTests
    {
        [Fact]
        public void extension_has_correct_static_members()
        {
            using (new AssertionScope())
            {
                HostingEnvironmentExtensions.Development.Should().Be("Development");
                HostingEnvironmentExtensions.Obiwankenobi.Should().Be("Obiwankenobi");
                HostingEnvironmentExtensions.Test.Should().Be("Test");
                HostingEnvironmentExtensions.Uat.Should().Be("Uat");
            }
        }

        [Fact]
        public void is_Development_one_of_our_development_environments_true_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Development");
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeTrue();
        }

        [Fact]
        public void is_Obiwankenobi_one_of_our_development_environments_true_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Obiwankenobi");
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeTrue();
        }

        [Fact]
        public void is_Test_one_of_our_test_environments_false_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Test");
            sut.Object.IsOneOfOurTestEnvironments().Should().BeTrue();
        }

        [Fact]
        public void is_Uat_one_of_our_test_environments_false_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Uat");
            sut.Object.IsOneOfOurTestEnvironments().Should().BeTrue();
        }
    }
}
