using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pubs.CoreDomain.Constants;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;

namespace Pubs.UnitTests.Persistence.Setup.Fixtures
{
    public class PubsContextInMemoryDatabaseFixture : IDisposable
    {
        public PubsContext PubsDbContext;


        public PubsContextInMemoryDatabaseFixture()
        {
            CreatePubsContext();
            SetupStaticTestData();
        }

        public void Dispose()
        {
            PubsDbContext?.Database.EnsureDeleted();
            PubsDbContext?.Dispose();
        }


        #region Private Methods

        private void CreatePubsContext()
        {
            var options = new DbContextOptionsBuilder<PubsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                // don't raise the error warning us that the in memory db doesn't support transactions
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            PubsDbContext = new PubsContext(options);

            PubsDbContext.Database.EnsureCreated();
            PubsDbContext.SaveChanges();

        }

        private void SetupStaticTestData()
        {
            SetupApplicationRoles();
            SetupApplicationUserStatuses();
            SetupJobs();
            SetupPublishers();
        }

        private void SetupApplicationRoles()
        {
            PubsDbContext.ApplicationRoles.AddRange(new List<ApplicationRole>
            {
                new ApplicationRole { Id = 1001, RoleName = ApplicationRoleNames.Administrator}
                ,new ApplicationRole { Id = 1002, RoleName = ApplicationRoleNames.User}
                ,new ApplicationRole { Id = 1003, RoleName = ApplicationRoleNames.ReadOnlyUser}
                ,new ApplicationRole { Id = 1004, RoleName = ApplicationRoleNames.PowerUser}
            });
            PubsDbContext.SaveChanges();
        }

        private void SetupApplicationUserStatuses()
        {
            PubsDbContext.ApplicationUserStatuses.AddRange(new List<ApplicationUserStatus>
            {
                new ApplicationUserStatus {Id = 1001, StatusAbbreviation = "A", StatusName = ApplicationUserStatusNames.Active}
                ,new ApplicationUserStatus {Id = 1002, StatusAbbreviation = "I", StatusName = ApplicationUserStatusNames.Inactive}
                ,new ApplicationUserStatus {Id = 1003, StatusAbbreviation = "L", StatusName = ApplicationUserStatusNames.Locked}
            });
            PubsDbContext.SaveChanges();
        }

        private void SetupJobs()
        {
            PubsDbContext.Jobs.AddRange(new List<Job>
            {
                new Job {Id = 1, JobDescription = "New Hire - Job not specified", MinimumLevel = 10, MaximumLevel = 10}
                ,new Job {Id = 2, JobDescription = "Chief Executive Officer", MinimumLevel = 200, MaximumLevel = 250}
                ,new Job {Id = 3, JobDescription = "Business Operations Manager", MinimumLevel = 175, MaximumLevel = 225}
                ,new Job {Id = 4, JobDescription = "Chief Financial Officer", MinimumLevel = 175, MaximumLevel = 250}
                ,new Job {Id = 5, JobDescription = "Publisher", MinimumLevel = 150, MaximumLevel = 250}
                ,new Job {Id = 6, JobDescription = "Managing Editor", MinimumLevel = 140, MaximumLevel = 225}
                ,new Job {Id = 7, JobDescription = "Marketing Manager", MinimumLevel = 120, MaximumLevel = 200}
                ,new Job {Id = 8, JobDescription = "Public Relations Manager", MinimumLevel = 100, MaximumLevel = 175}
                ,new Job {Id = 9, JobDescription = "Acquisitions Manager", MinimumLevel = 75, MaximumLevel = 175}
                ,new Job {Id = 10, JobDescription = "Productions Manager", MinimumLevel = 75, MaximumLevel = 165}
                ,new Job {Id = 11, JobDescription = "Operations Manager", MinimumLevel = 75, MaximumLevel = 150}
                ,new Job {Id = 12, JobDescription = "Editor", MinimumLevel = 25, MaximumLevel = 100}
                ,new Job {Id = 13, JobDescription = "Sales Representative", MinimumLevel = 25, MaximumLevel = 100}
                ,new Job {Id = 14, JobDescription = "Designer", MinimumLevel = 25, MaximumLevel = 100}
            });
            PubsDbContext.SaveChanges();
        }

        private void SetupPublishers()
        {
            PubsDbContext.Publishers.AddRange(new List<Publisher>
            {
                new Publisher{Id= 1,PublisherCode = "0736", PublisherName = "New Moon Books", City = "Boston", State = "MA", Country = "USA"}
                ,new Publisher{Id= 2,PublisherCode = "0877", PublisherName = "Binnet & Hardley", City = "Washington", State = "DC", Country = "USA"}
                ,new Publisher{Id= 3,PublisherCode = "1389", PublisherName = "Algodata Infosystems", City = "Berkeley", State = "CA", Country = "USA"}
                ,new Publisher{Id= 4,PublisherCode = "9952", PublisherName = "Scootney Books", City = "New York", State = "NY", Country = "USA"}
                ,new Publisher{Id= 5,PublisherCode = "1622", PublisherName = "Five Lakes Publishing", City = "Chicago", State = "IL", Country = "USA"}
                ,new Publisher{Id= 6,PublisherCode = "1756", PublisherName = "Ramona Publishers", City = "Dallas", State = "TX", Country = "USA"}
                ,new Publisher{Id= 7,PublisherCode = "9901", PublisherName = "GGG&G", City = "Munchen", Country = "Germany"}
                ,new Publisher{Id= 8,PublisherCode = "9999", PublisherName = "Lucerne Publishing", City = "Paris", Country = "France"}
            }
            );
        }

        #endregion Private Methods
    }
}
