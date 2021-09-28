using ConfigurationSubstitution;
using Microsoft.Extensions.Configuration;

namespace Pubs.Web.Tests.Factories
{
    public class WebTestConfigFactory
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                        .AddJsonFile("Pubs.Web.Tests.Settings.json")
                        .AddEnvironmentVariables()
                        .EnableSubstitutions("%%", "%%")
                        .Build();
        }
    }
}
