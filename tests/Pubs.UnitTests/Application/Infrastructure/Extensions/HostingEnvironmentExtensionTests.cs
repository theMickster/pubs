using FluentAssertions.Execution;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Xunit;
using Pubs.Application.Infrastructure.Extensions;
using HostingEnvironmentExtensions = Pubs.Application.Infrastructure.Extensions.HostingEnvironmentExtensions;
using FluentAssertions;
using Pubs.UnitTests.Setup;
using Microsoft.Extensions.Hosting;

namespace Pubs.UnitTests.Application.Infrastructure.Extensions
{
    public class HostingEnvironmentExtensionTests : UnitTestBase
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
        public void web_host_is_Development_one_of_our_development_environments_true_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Development");
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurTestEnvironments().Should().BeFalse();
        }

        [Fact]
        public void web_host_is_Obiwankenobi_one_of_our_development_environments_true_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Obiwankenobi");
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurTestEnvironments().Should().BeFalse();
        }

        [Fact]
        public void web_host_is_Test_one_of_our_test_environments_false_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Test");
            sut.Object.IsOneOfOurTestEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeFalse();
        }

        [Fact]
        public void web_host_is_Uat_one_of_our_test_environments_false_succeeds()
        {
            var sut = new Mock<IWebHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Uat");
            sut.Object.IsOneOfOurTestEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeFalse();
        }

        [Fact]
        public void host_is_Development_one_of_our_development_environments_true_succeeds()
        {
            var sut = new Mock<IHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Development");
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurTestEnvironments().Should().BeFalse();
        }

        [Fact]
        public void host_is_Obiwankenobi_one_of_our_development_environments_true_succeeds()
        {
            var sut = new Mock<IHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Obiwankenobi");
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurTestEnvironments().Should().BeFalse();
        }

        [Fact]
        public void host_is_Test_one_of_our_test_environments_false_succeeds()
        {
            var sut = new Mock<IHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Test");
            sut.Object.IsOneOfOurTestEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeFalse();
        }

        [Fact]
        public void host_is_Uat_one_of_our_test_environments_false_succeeds()
        {
            var sut = new Mock<IHostEnvironment>();
            sut.Setup(s => s.EnvironmentName).Returns("Uat");
            sut.Object.IsOneOfOurTestEnvironments().Should().BeTrue();
            sut.Object.IsOneOfOurDevelopmentEnvironments().Should().BeFalse();
        }
    }
}
