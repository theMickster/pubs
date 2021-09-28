using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.SharedKernel.Tests.Extensions.DbContext;
using System;

namespace Pubs.SharedKernel.Tests.Factories
{
    public class PubsTestDbContextFactory
    {
        public PubsContext Create()
        {
            var options = new DbContextOptionsBuilder<PubsContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            // don't raise the error warning us that the in memory db doesn't support transactions
                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                            .Options;

            var context = new PubsContext(options);

            context.SeedInMemoryDatabase();

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
