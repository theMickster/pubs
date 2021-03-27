using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pubs.Application.Common.Helpers;
using Pubs.Infrastructure.Persistence.DbContexts;
using System;

namespace Pubs.Infrastructure.Persistence.Unit.Tests.Factories
{
    public class PubsContextFactory
    {
        public PubsContext Create()
        {
            var options = new DbContextOptionsBuilder<PubsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var defaultSchema = new DbContextSchemaHelper(configuration["DefaultSchema"]);

            var context = new PubsContext(options, defaultSchema);

            context.Database.EnsureCreated();
                       
            context.SaveChanges();

            return context;
        }

        public void Destroy(PubsContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
