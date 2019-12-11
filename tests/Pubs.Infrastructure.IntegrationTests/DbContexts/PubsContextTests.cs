using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.Application.Common.Helpers;
using System;
using System.Linq;
using Xunit;

namespace Pubs.Infrastructure.IntegrationTests.DbContexts
{
    public class PubsContextTests : IDisposable
    {
        private readonly PubsContext _context;

        public PubsContextTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

            var defaultSchema = new DbContextSchemaHelper(configuration["DefaultSchema"]);

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<PubsContext>();

            builder.UseSqlServer(connectionString)
                .UseInternalServiceProvider(serviceProvider);

            _context = new PubsContext(builder.Options, defaultSchema);

        }

        public void Dispose()
        {
            _context?.Dispose();
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

        [Fact]
        public void retrieving_authors_with_dummy_data_succeeds()
        {
            //Arrange
            var author = _context.Authors.Where(a => a.City == "Dummy Data");

            //Act
            var data = author.ToList();

            Assert.NotNull(data);
            Assert.Empty(data);

        }



        
    }
}
