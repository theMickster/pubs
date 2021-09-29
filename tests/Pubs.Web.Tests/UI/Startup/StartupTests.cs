using FluentAssertions;
using FluentAssertions.Execution;
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
        private readonly HttpClient _client;

        public StartupTests(PubsWebApplicationFixture<Pubs.UI.Startup> factory)
        {
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
