using Pubs.CoreDomain.Constants;
using Pubs.CoreDomain.Entities;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.DbContexts;
using System.Collections.Generic;

namespace Pubs.SharedKernel.Tests.Extensions.DbContext
{
    public static class PubsContextExtensions
    {
        public static void SeedInMemoryDatabase(this PubsContext dbContext)
        {
            SetupApplicationRoles(dbContext);
            SetupApplicationUserStatuses(dbContext);
            SetupJobs(dbContext);
            SetupPublishers(dbContext);
            SetupAuthors(dbContext);

            dbContext.SaveChanges();
        }


        #region Private Methods

        private static void SetupApplicationRoles(PubsContext dbContext)
        {
            dbContext.ApplicationRoles.AddRange(new List<ApplicationRole>
            {
                new ApplicationRole { Id = 1001, RoleName = ApplicationRoleNames.Administrator}
                ,new ApplicationRole { Id = 1002, RoleName = ApplicationRoleNames.User}
                ,new ApplicationRole { Id = 1003, RoleName = ApplicationRoleNames.ReadOnlyUser}
                ,new ApplicationRole { Id = 1004, RoleName = ApplicationRoleNames.PowerUser}
            });
            dbContext.SaveChanges();
        }

        private static void SetupApplicationUserStatuses(PubsContext dbContext)
        {
            dbContext.ApplicationUserStatuses.AddRange(new List<ApplicationUserStatus>
            {
                new ApplicationUserStatus {Id = 1001, StatusAbbreviation = "A", StatusName = ApplicationUserStatusNames.Active}
                ,new ApplicationUserStatus {Id = 1002, StatusAbbreviation = "I", StatusName = ApplicationUserStatusNames.Inactive}
                ,new ApplicationUserStatus {Id = 1003, StatusAbbreviation = "L", StatusName = ApplicationUserStatusNames.Locked}
            });
            dbContext.SaveChanges();
        }

        private static void SetupAuthors(PubsContext dbContext)
        {
            dbContext.Authors.AddRange(new List<Author>
            {
                new Author() {Id = 1, AuthorCode = "409-56-7008", FirstName = "Abraham", LastName = "Bennet", Address = "6223 Bateman St.", City = "Berkeley", State = "CA", ZipCode = "94705", PhoneNumber = "415 658-9932", Contract = true },
                new Author() {Id = 2, AuthorCode = "213-46-8915", FirstName = "Marjorie", LastName = "Green", Address = "309 63rd St. #411", City = "Oakland", State = "CA", ZipCode = "94618", PhoneNumber = "415 986-7020", Contract = true },
                new Author() {Id = 3, AuthorCode = "238-95-7766", FirstName = "Cheryl", LastName = "Carson", Address = "589 Darwin Ln.", City = "Berkeley", State = "CA", ZipCode = "94705", PhoneNumber = "415 548-7723", Contract = true },
                new Author() {Id = 4, AuthorCode = "998-72-3567", FirstName = "Albert", LastName = "Ringer", Address = "67 Seventh Av.", City = "Salt Lake City", State = "UT", ZipCode = "84152", PhoneNumber = "801 826-0752", Contract = true },
                new Author() {Id = 5, AuthorCode = "899-46-2035", FirstName = "Anne", LastName = "Ringer", Address = "67 Seventh Av.", City = "Salt Lake City", State = "UT", ZipCode = "84152", PhoneNumber = "801 826-0752", Contract = true },
                new Author() {Id = 6, AuthorCode = "722-51-5454", FirstName = "Michel", LastName = "DeFrance", Address = "3 Balding Pl.", City = "Gary", State = "IN", ZipCode = "46403", PhoneNumber = "219 547-9982", Contract = true },
                new Author() {Id = 7, AuthorCode = "807-91-6654", FirstName = "Sylvia", LastName = "Panteley", Address = "1956 Arlington Pl.", City = "Rockville", State = "MD", ZipCode = "20853", PhoneNumber = "301 946-8853", Contract = true },
                new Author() {Id = 8, AuthorCode = "893-72-1158", FirstName = "Heather", LastName = "McBadden", Address = "301 Putnam", City = "Vacaville", State = "CA", ZipCode = "95688", PhoneNumber = "707 448-4982", Contract = false },
                new Author() {Id = 9, AuthorCode = "724-08-9931", FirstName = "Dirk", LastName = "Stringer", Address = "5420 Telegraph Av.", City = "Oakland", State = "CA", ZipCode = "94609", PhoneNumber = "415 843-2991", Contract = false },
                new Author() {Id = 10, AuthorCode = "274-80-9391", FirstName = "Dean", LastName = "Straight", Address = "5420 College Av.", City = "Oakland", State = "CA", ZipCode = "94609", PhoneNumber = "415 834-2919", Contract = true },
                new Author() {Id = 11, AuthorCode = "756-30-7391", FirstName = "Livia", LastName = "Karsen", Address = "5720 McAuley St.", City = "Oakland", State = "CA", ZipCode = "94609", PhoneNumber = "415 534-9219", Contract = true },
                new Author() {Id = 12, AuthorCode = "724-80-9391", FirstName = "Stearns", LastName = "MacFeather", Address = "44 Upland Hts.", City = "Oakland", State = "CA", ZipCode = "94612", PhoneNumber = "415 354-7128", Contract = true },
                new Author() {Id = 13, AuthorCode = "427-17-2319", FirstName = "Ann", LastName = "Dull", Address = "3410 Blonde St.", City = "Palo Alto", State = "CA", ZipCode = "94301", PhoneNumber = "415 836-7128", Contract = true },
                new Author() {Id = 14, AuthorCode = "672-71-3249", FirstName = "Akiko", LastName = "Yokomoto", Address = "3 Silver Ct.", City = "Walnut Creek", State = "CA", ZipCode = "94595", PhoneNumber = "415 935-4228", Contract = true },
                new Author() {Id = 15, AuthorCode = "267-41-2394", FirstName = "Michael", LastName = "O'Leary", Address = "22 Cleveland Av. #14", City = "San Jose", State = "CA", ZipCode = "95128", PhoneNumber = "408 286-2428", Contract = true },
                new Author() {Id = 16, AuthorCode = "472-27-2349", FirstName = "Burt", LastName = "Gringlesby", Address = "PO Box 792", City = "Covelo", State = "CA", ZipCode = "95428", PhoneNumber = "707 938-6445", Contract = true },
                new Author() {Id = 17, AuthorCode = "527-72-3246", FirstName = "Morningstar", LastName = "Greene", Address = "22 Graybar House Rd.", City = "Nashville", State = "TN", ZipCode = "37215", PhoneNumber = "615 297-2723", Contract = false },
                new Author() {Id = 18, AuthorCode = "172-32-1176", FirstName = "Johnson", LastName = "White", Address = "10932 Bigge Rd.", City = "Menlo Park", State = "CA", ZipCode = "94025", PhoneNumber = "408 496-7223", Contract = true },
                new Author() {Id = 19, AuthorCode = "712-45-1867", FirstName = "Innes", LastName = "del Castillo", Address = "2286 Cram Pl. #86", City = "Ann Arbor", State = "MI", ZipCode = "48105", PhoneNumber = "615 996-8275", Contract = true },
                new Author() {Id = 20, AuthorCode = "846-92-7186", FirstName = "Sheryl", LastName = "Hunter", Address = "3410 Blonde St.", City = "Palo Alto", State = "CA", ZipCode = "94301", PhoneNumber = "415 836-7128", Contract = true },
                new Author() {Id = 21, AuthorCode = "486-29-1786", FirstName = "Charlene", LastName = "Locksley", Address = "18 Broadway Av.", City = "San Francisco", State = "CA", ZipCode = "94130", PhoneNumber = "415 585-4620", Contract = true },
                new Author() {Id = 22, AuthorCode = "648-92-1872", FirstName = "Reginald", LastName = "Blotchet-Halls", Address = "55 Hillsdale Bl.", City = "Corvallis", State = "OR", ZipCode = "97330", PhoneNumber = "503 745-6402", Contract = true },
                new Author() {Id = 23, AuthorCode = "341-22-1782", FirstName = "Meander", LastName = "Smith", Address = "10 Mississippi Dr.", City = "Lawrence", State = "KS", ZipCode = "66044", PhoneNumber = "913 843-0462", Contract = false }                
            });
            dbContext.SaveChanges();
        }

        private static void SetupJobs(PubsContext dbContext)
        {
            dbContext.Jobs.AddRange(new List<Job>
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
            dbContext.SaveChanges();
        }

        private static void SetupPublishers(PubsContext dbContext)
        {
            dbContext.Publishers.AddRange(new List<Publisher>
            {
                new Publisher{Id= 1,PublisherCode = "0736", PublisherName = "New Moon Books", City = "Boston", State = "MA", Country = "USA"}
                ,new Publisher{Id= 2,PublisherCode = "0877", PublisherName = "Binnet & Hardley", City = "Washington", State = "DC", Country = "USA"}
                ,new Publisher{Id= 3,PublisherCode = "1389", PublisherName = "Algodata Infosystems", City = "Berkeley", State = "CA", Country = "USA"}
                ,new Publisher{Id= 4,PublisherCode = "9952", PublisherName = "Scootney Books", City = "New York", State = "NY", Country = "USA"}
                ,new Publisher{Id= 5,PublisherCode = "1622", PublisherName = "Five Lakes Publishing", City = "Chicago", State = "IL", Country = "USA"}
                ,new Publisher{Id= 6,PublisherCode = "1756", PublisherName = "Ramona Publishers", City = "Dallas", State = "TX", Country = "USA"}
                ,new Publisher{Id= 7,PublisherCode = "9901", PublisherName = "GGG&G", City = "Munchen", Country = "Germany"}
                ,new Publisher{Id= 8,PublisherCode = "9999", PublisherName = "Lucerne Publishing", City = "Paris", Country = "France"}
            });
            dbContext.SaveChanges();
        }

        #endregion Private Methods
    }
}
