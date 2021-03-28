using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pubs.Infrastructure.Persistence.DbContexts;
using System;

namespace Pubs.Application.UnitTests.Setup.Fixtures
{
    public class PubsContextInMemoryDatabaseFixture : IDisposable
    {
        public PubsContext PubsDbContext;


        public PubsContextInMemoryDatabaseFixture()
        {
            PubsDbContext = Create();
        }

        private PubsContext Create()
        {
            var options = new DbContextOptionsBuilder<PubsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                // don't raise the error warning us that the in memory db doesn't support transactions
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new PubsContext(options);

            context.Database.EnsureCreated();

            context.SaveChanges();

            return context;
        }

        public void Dispose()
        {
            PubsDbContext?.Database.EnsureDeleted();
            PubsDbContext?.Dispose();
        }
    }
}
