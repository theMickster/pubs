using Microsoft.EntityFrameworkCore;
using Pubs.Infrastructure.Interfaces;

namespace Pubs.Infrastructure.DbContexts
{
    public class PubsContext : DbContext, IPubsContext
    {
        public PubsContext(DbContextOptions<PubsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}