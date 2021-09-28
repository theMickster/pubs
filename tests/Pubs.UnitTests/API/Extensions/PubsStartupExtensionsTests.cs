using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pubs.API.Extensions;
using Xunit;

namespace Pubs.UnitTests.API.Extensions
{
    public class PubsStartupExtensionsTests
    {
        [Fact]
        public void cross_origin_resource_sharing_is_registered_succeeds()
        {
            IServiceCollection services = new ServiceCollection();
            IConfiguration configuration = null;

            services.AddPubsCustomMVC(configuration);

            using (new AssertionScope())
            {
                using var scope = services.BuildServiceProvider().CreateScope();

                var options = scope.ServiceProvider.GetService<IOptions<CorsOptions>>();
                options?.Value?.Should().NotBeNull();

                if (options?.Value != null)
                {
                    var expectedPolicy = options.Value.GetPolicy("PubsCorsPolicy");
                    expectedPolicy?.Should().NotBeNull();
                    if (expectedPolicy != null)
                    {
                        expectedPolicy.AllowAnyOrigin.Should().BeFalse();
                        expectedPolicy.AllowAnyMethod.Should().BeTrue();
                        expectedPolicy.AllowAnyHeader.Should().BeTrue();
                        expectedPolicy.SupportsCredentials.Should().BeTrue();
                    }
                }
            }
        }

    }
}
