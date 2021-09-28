using ConfigurationSubstitution;
using Microsoft.Extensions.Configuration;

namespace Pubs.WebAPI.Tests.Factories
{
    public static class WebApiTestConfigFactory
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                        .AddJsonFile("Pubs.WebAPI.Tests.Settings.json")
                        .AddEnvironmentVariables()
                        .EnableSubstitutions("%%", "%%")
                        .Build();
        }
    }
}
