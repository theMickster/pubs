using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Settings;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.WebAPI.Tests.Fixtures;
using Pubs.WebAPI.Tests.Setup;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Pubs.WebAPI.Tests.API.Startup
{
    public class StartupTests : WebApiTestBase, IClassFixture<PubsWebApiApplicationFixture<Pubs.API.Startup>>
    {
        private readonly PubsWebApiApplicationFixture<Pubs.API.Startup> _webApiAppFactory;
        private readonly HttpClient _client;

        public StartupTests(PubsWebApiApplicationFixture<Pubs.API.Startup> factory)
        {
            _webApiAppFactory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task factory_builds_with_pubs_api_startup_succeeds()
        {
            var response = await _client.GetAsync("/");
            using (new AssertionScope())
            {
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task swaggar_endpoint_retrieval_succeeds()
        {
            var response = await _client.GetAsync("/swagger/index.html");
            using (new AssertionScope())
            {
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public void settings_objects_are_registered_succeeds()
        {
            using var scope = _webApiAppFactory.Services.CreateScope();
            using (new AssertionScope())
            {
                scope.ServiceProvider.GetRequiredService<IOptions<EntityFrameworkCoreSettings>>().Should().NotBeNull();
            }
        }

        [Fact]
        public void repository_objects_are_registered_succeeds()
        {
            using var scope = _webApiAppFactory.Services.CreateScope();
            using (new AssertionScope())
            {
                scope.ServiceProvider.GetRequiredService<IAuthorRepository>().Should().NotBeNull();
            }
        }

        [Fact]
        public void db_context_objects_are_registered_succeeds()
        {
            using var scope = _webApiAppFactory.Services.CreateScope();
            using (new AssertionScope())
            {
                scope.ServiceProvider.GetRequiredService<PubsContext>().Should().NotBeNull();
            }
        }
    }
}
