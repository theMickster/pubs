using System;
using Microsoft.EntityFrameworkCore;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;

namespace Pubs.Application.Interfaces.DbContexts
{
    public interface IPubsContext : IDisposable
    {
        DbSet<Author> Authors { get; set; }

        DbSet<Book> Books { get; set; }

        DbSet<Discount> Discounts { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Job> Jobs { get; set; }

        DbSet<Publisher> Publishers { get; set; }

        DbSet<PublisherLogo> PublisherLogos { get; set; }

        DbSet<Royalty> Royalties { get; set; }

        DbSet<Sale> Sales { get; set; }

        DbSet<Store> Stores { get; set; }

        DbSet<Title> Titles { get; set; }

        DbSet<ApplicationRole> ApplicationRoles { get; set; }

        DbSet<ApplicationUser> ApplicationUsers { get; set; }

        DbSet<ApplicationUserStatus> ApplicationUserStatuses { get; set; }

        DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

    }
}