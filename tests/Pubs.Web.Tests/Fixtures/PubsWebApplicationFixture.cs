using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pubs.Web.Tests.Factories;
using System;

namespace Pubs.Web.Tests.Fixtures
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
    public class PubsWebApplicationFixture<TStartup> : WebApplicationFactory<Pubs.UI.Startup>
    {
        private IConfigurationRoot _configurationRoot;

        public PubsWebApplicationFixture()
        {
            ClientOptions.BaseAddress = new Uri("https://localhost:7256");
        }

        public IConfigurationRoot ConfigurationRoot => _configurationRoot ??= WebTestConfigFactory.GetConfiguration();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development")
                .ConfigureAppConfiguration(config =>
                {
                    config.AddConfiguration(ConfigurationRoot);
                })
               .ConfigureTestServices(services =>
               {
                   services.AddControllers();
                   //.ConfigureApplicationPartManager(a =>
                   //    a.ApplicationParts.Add(new AssemblyPart(typeof(FakeHomeController).GetTypeInfo().Assembly)));

                   //services.AddSingleton<IUserRepository, FakeUserRepository>();

                   //*************************************************
                   // Adding a hook to remove background services.
                   //*************************************************
                   //var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ImplementationType == typeof(TimedCachedDataService));
                   //if (serviceDescriptor != null)
                   //{
                   //    services.Remove(serviceDescriptor);
                   //}
                   //serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ImplementationType == typeof(TimedManualElementUpdateService));
                   //if (serviceDescriptor != null)
                   //{
                   //    services.Remove(serviceDescriptor);
                   //}
               });

            base.ConfigureWebHost(builder);
        }
    }
}
