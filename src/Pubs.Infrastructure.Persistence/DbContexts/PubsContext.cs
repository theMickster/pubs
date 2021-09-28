using Microsoft.EntityFrameworkCore;
using Pubs.Application.Common.Interfaces;
using Pubs.Application.Interfaces.DbContexts;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.EntityConfigurations;
using System.Reflection;

namespace Pubs.Infrastructure.Persistence.DbContexts
{
    public class PubsContext : DbContext, IPubsContext, IDbContextSchema
    {
        public string DefaultSchema { get; }

        public PubsContext(DbContextOptions<PubsContext> options
                            ,IDbContextSchema schema = null) : base(options)
        {
            DefaultSchema = schema?.DefaultSchema ?? "dbo";
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

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationUserStatus> ApplicationUserStatuses { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new BookConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new DiscountConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new JobConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new PublisherConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new PublisherLogoConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new RoyaltyConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new SaleConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new StoreConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new TitleConfiguration(DefaultSchema));

            modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration(DefaultSchema));
            modelBuilder.ApplyConfiguration(new ApplicationUserStatusConfiguration(DefaultSchema));
        }
    }
}