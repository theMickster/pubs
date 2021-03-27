using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pubs.Application.Common.Helpers;
using Pubs.Infrastructure.Persistence.DbContexts;

namespace Pubs.Infrastructure.IntegrationTests.Setup.Factories
{
    public class LiveSqlServerPubsContextFactory
    {
        public PubsContext Create()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var configuration = IntegrationTestConfigFactory.GetConfiguration();

            var defaultSchema = new DbContextSchemaHelper(configuration["DefaultSchema"]);

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<PubsContext>();

            builder.UseSqlServer(connectionString)
                .UseInternalServiceProvider(serviceProvider);

            return new PubsContext(builder.Options, defaultSchema);
        }

        public void Destroy(PubsContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
