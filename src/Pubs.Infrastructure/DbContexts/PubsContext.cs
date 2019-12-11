using Microsoft.EntityFrameworkCore;
using Pubs.Core.Entities;
using Pubs.Infrastructure.EntityConfigurations;
using Pubs.Infrastructure.Interfaces;

namespace Pubs.Infrastructure.DbContexts
{
    public class PubsContext : DbContext, IPubsContext
    {
        public PubsContext(DbContextOptions<PubsContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherLogo> PublisherLogos { get; set; }
        public DbSet<Royalty> Royalties { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Title> Titles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherLogoConfiguration());
            modelBuilder.ApplyConfiguration(new RoyaltyConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
        }
    }
}