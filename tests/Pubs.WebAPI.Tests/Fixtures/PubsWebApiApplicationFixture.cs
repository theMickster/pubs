using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.SharedKernel.Tests.Extensions.DbContext;
using Pubs.WebAPI.Tests.Factories;
using System;
using System.Linq;

namespace Pubs.WebAPI.Tests.Fixtures
{
    /// <summary>
    /// This is used to create a TestServer for the integration tests. 
    /// The startup class is defined as the same class that the live web app uses.
    /// </summary>
    /// <remarks>
    /// For more information, please see: 
    /// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1
    /// </remarks>
    /// <typeparam name="TStartup"></typeparam>
    public class PubsWebApiApplicationFixture<TStartup> : WebApplicationFactory<Pubs.API.Startup>
    {
        private IConfigurationRoot _configurationRoot;

        public PubsWebApiApplicationFixture()
        {
            ClientOptions.BaseAddress = new Uri("https://localhost:7256");
        }

        public IConfigurationRoot ConfigurationRoot => _configurationRoot ??= WebApiTestConfigFactory.GetConfiguration();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var pubsDbContextSource = ConfigurationRoot.GetValue<string>("PubsDbContextSource");

            if (pubsDbContextSource == null)
            {
                throw new Exception("The test configuration key/value pair named 'PubsDbContextSource' cannot be found.");
            }

            builder.UseEnvironment("Development");

            builder.ConfigureAppConfiguration(config =>
            {
                config.AddConfiguration(ConfigurationRoot);
            });

            builder.ConfigureServices(services =>
            {
                services.AddControllers();

                if (pubsDbContextSource.Trim().ToLower() == "InMemory".ToLower())
                {
                    var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<PubsContext>));
                    if (serviceDescriptor != null)
                    {
                        services.Remove(serviceDescriptor);
                    }

                    services.AddEntityFrameworkInMemoryDatabase();

                    var provider = services
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    services.AddDbContext<PubsContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(provider);
                        //options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    });

                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var inMemoryDatabase = scopedServices.GetRequiredService<PubsContext>();

                    inMemoryDatabase.Database.EnsureCreated();
                    inMemoryDatabase.SeedInMemoryDatabase();
                }
            });

            base.ConfigureWebHost(builder);
        }
    }
}
