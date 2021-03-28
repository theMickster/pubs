using Microsoft.Extensions.Configuration;

namespace Pubs.Infrastructure.IntegrationTests.Setup.Factories
{
    public static class IntegrationTestConfigFactory
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("IntegrationTestSettings.json")
                .AddUserSecrets<IntegrationTestBase>()
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
