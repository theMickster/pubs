using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Settings;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.Web.Tests.Fixtures;
using Pubs.Web.Tests.Setup;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Pubs.Web.Tests.UI.Startup
{
    public class StartupTests : WebTestBase, IClassFixture<PubsWebApplicationFixture<Pubs.UI.Startup>>
    {
        private readonly PubsWebApplicationFixture<Pubs.UI.Startup> _webAppFactory;
        private readonly HttpClient _client;

        public StartupTests(PubsWebApplicationFixture<Pubs.UI.Startup> factory)
        {
            _webAppFactory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task factory_builds_with_pubs_ui_startup_succeeds()
        {
            var response = await _client.GetAsync("/");
            using (new AssertionScope())
            {
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

    }
}
