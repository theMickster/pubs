using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pubs.Infrastructure.DbContexts;
using System.Linq;
using Xunit;

namespace Pubs.Infrastructure.IntegrationTests.DbContexts
{
    public class PubsContextTests 
    {
        private readonly PubsContext _context;

        public PubsContextTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<PubsContext>();

            builder.UseSqlServer($"Server = (local); Database = Pubs; Trusted_Connection=True; MultipleActiveResultSets=true; Application Name=Pubs Integration Tests")
                .UseInternalServiceProvider(serviceProvider);

            _context = new PubsContext(builder.Options);

        }

        [Fact]
        public void retrieving_authors_from_database_succeeds()
        {
            //Arrange + Act (not really acting on the authors list).
            var author = _context.Authors.Where(a => a.Id == 1).ToList();
            
            //Assert
            Assert.NotNull(author);
            Assert.Single(author);
            Assert.Equal("Bennet", author.Single()?.LastName);
        }



        
    }
}
