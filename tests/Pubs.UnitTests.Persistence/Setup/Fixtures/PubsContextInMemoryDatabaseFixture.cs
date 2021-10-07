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
            SetupAuthors();
            SetupAuthorTitles();
            SetupTitles();
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
            });
            PubsDbContext.SaveChanges();
        }

        private void SetupAuthors()
        {
            PubsDbContext.Authors.AddRange(new List<Author>
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

            PubsDbContext.SaveChanges();
        }

        private void SetupAuthorTitles()
        {
            PubsDbContext.AuthorTitles.AddRange(new List<AuthorTitle>
            {
                new AuthorTitle() { Id = 1, AuthorId = 1, TitleId = 2, TitleCode = "BU1032", AuthorCode = "409-56-7008", AuthorOrder = 1,  Royalty = 60 },
                new AuthorTitle() { Id = 2, AuthorId = 21, TitleId = 3, TitleCode = "PS7777", AuthorCode = "486-29-1786", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 3, AuthorId = 21, TitleId = 18, TitleCode = "PC9999", AuthorCode = "486-29-1786", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 4, AuthorId = 19, TitleId = 6, TitleCode = "MC2222", AuthorCode = "712-45-1867", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 5, AuthorId = 18, TitleId = 4, TitleCode = "PS3333", AuthorCode = "172-32-1176", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 6, AuthorId = 2, TitleId = 2, TitleCode = "BU1032", AuthorCode = "213-46-8915", AuthorOrder = 2,  Royalty = 40 },
                new AuthorTitle() { Id = 7, AuthorId = 3, TitleId = 9, TitleCode = "PC1035", AuthorCode = "238-95-7766", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 8, AuthorId = 2, TitleId = 10, TitleCode = "BU2075", AuthorCode = "213-46-8915", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 9, AuthorId = 4, TitleId = 11, TitleCode = "PS2091", AuthorCode = "998-72-3567", AuthorOrder = 1,  Royalty = 50 },
                new AuthorTitle() { Id = 10, AuthorId = 5, TitleId = 11, TitleCode = "PS2091", AuthorCode = "899-46-2035", AuthorOrder = 2,  Royalty = 50 },
                new AuthorTitle() { Id = 11, AuthorId = 4, TitleId = 12, TitleCode = "PS2106", AuthorCode = "998-72-3567", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 12, AuthorId = 6, TitleId = 13, TitleCode = "MC3021", AuthorCode = "722-51-5454", AuthorOrder = 1,  Royalty = 75 },
                new AuthorTitle() { Id = 13, AuthorId = 5, TitleId = 13, TitleCode = "MC3021", AuthorCode = "899-46-2035", AuthorOrder = 2,  Royalty = 25 },
                new AuthorTitle() { Id = 14, AuthorId = 7, TitleId = 14, TitleCode = "TC3218", AuthorCode = "807-91-6654", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 15, AuthorId = 10, TitleId = 16, TitleCode = "BU7832", AuthorCode = "274-80-9391", AuthorOrder = 1,  Royalty = 100 },
                new AuthorTitle() { Id = 16, AuthorId = 13, TitleId = 1, TitleCode = "PC8888", AuthorCode = "427-17-2319", AuthorOrder = 1,  Royalty = 50 },
                new AuthorTitle() { Id = 17, AuthorId = 20, TitleId = 1, TitleCode = "PC8888", AuthorCode = "846-92-7186", AuthorOrder = 2,  Royalty = 50 },
                new AuthorTitle() { Id = 18, AuthorId = 11, TitleId = 17, TitleCode = "PS1372", AuthorCode = "756-30-7391", AuthorOrder = 1,  Royalty = 75 },
                new AuthorTitle() { Id = 19, AuthorId = 12, TitleId = 17, TitleCode = "PS1372", AuthorCode = "724-80-9391", AuthorOrder = 2,  Royalty = 25 },
                new AuthorTitle() { Id = 20, AuthorId = 12, TitleId = 5, TitleCode = "BU1111", AuthorCode = "724-80-9391", AuthorOrder = 1,  Royalty = 60 },
                new AuthorTitle() { Id = 21, AuthorId = 15, TitleId = 5, TitleCode = "BU1111", AuthorCode = "267-41-2394", AuthorOrder = 2,  Royalty = 40 },
                new AuthorTitle() { Id = 22, AuthorId = 14, TitleId = 7, TitleCode = "TC7777", AuthorCode = "672-71-3249", AuthorOrder = 1,  Royalty = 40 },
                new AuthorTitle() { Id = 23, AuthorId = 15, TitleId = 7, TitleCode = "TC7777", AuthorCode = "267-41-2394", AuthorOrder = 2,  Royalty = 30 },
                new AuthorTitle() { Id = 24, AuthorId = 16, TitleId = 7, TitleCode = "TC7777", AuthorCode = "472-27-2349", AuthorOrder = 3,  Royalty = 30 },
                new AuthorTitle() { Id = 25, AuthorId = 22, TitleId = 8, TitleCode = "TC4203", AuthorCode = "648-92-1872", AuthorOrder = 1,  Royalty = 100  }
            });

            PubsDbContext.SaveChanges();
        }

        private void SetupTitles()
        {
            PubsDbContext.Titles.AddRange(new List<Title>
            {
                new Title() { Id = 1, TitleCode = "PC8888", TitleName = "Secrets of Silicon Valley", TitleType = "popular_comp", PublisherId = 3, PublisherCode = "1389", Price = 20.00m,  Royalty = 10,  YearToDateSales = 4095, Notes = "Muckraking reporting on the world's largest computer hardware and software manufacturers.", PublishedDate = new DateTime(1994,6,12) },
                new Title() { Id = 2, TitleCode = "BU1032", TitleName = "The Busy Executive's Database Guide", TitleType = "business    ", PublisherId = 3, PublisherCode = "1389", Price = 19.99m,  Royalty = 10,  YearToDateSales = 4095, Notes = "An overview of available database systems with emphasis on common business applications. Illustrated.", PublishedDate = new DateTime(1991,6,12) },
                new Title() { Id = 3, TitleCode = "PS7777", TitleName = "Emotional Security: A New Algorithm", TitleType = "psychology  ", PublisherId = 1, PublisherCode = "0736", Price = 7.99m,  Royalty = 10,  YearToDateSales = 3336, Notes = "Protecting yourself and your loved ones from undue emotional stress in the modern world. Use of computer and nutritional aids emphasized.", PublishedDate = new DateTime(1991,6,12) },
                new Title() { Id = 4, TitleCode = "PS3333", TitleName = "Prolonged Data Deprivation: Four Case Studies", TitleType = "psychology  ", PublisherId = 1, PublisherCode = "0736", Price = 19.99m,  Royalty = 10,  YearToDateSales = 4072, Notes = "What happens when the data runs dry?  Searching evaluations of information-shortage effects.", PublishedDate = new DateTime(1991,6,12) },
                new Title() { Id = 5, TitleCode = "BU1111", TitleName = "Cooking with Computers: Surreptitious Balance Sheets", TitleType = "business    ", PublisherId = 3, PublisherCode = "1389", Price = 11.95m,  Royalty = 10,  YearToDateSales = 3876, Notes = "Helpful hints on how to use your electronic resources to the best advantage.", PublishedDate = new DateTime(1991,6,9) },
                new Title() { Id = 6, TitleCode = "MC2222", TitleName = "Silicon Valley Gastronomic Treats", TitleType = "mod_cook    ", PublisherId = 2, PublisherCode = "0877", Price = 19.99m,  Royalty = 12,  YearToDateSales = 2032, Notes = "Favorite recipes for quick, easy, and elegant meals.", PublishedDate = new DateTime(1991,6,9) },
                new Title() { Id = 7, TitleCode = "TC7777", TitleName = "Sushi, Anyone?", TitleType = "trad_cook   ", PublisherId = 2, PublisherCode = "0877", Price = 14.99m,  Royalty = 10,  YearToDateSales = 4095, Notes = "Detailed instructions on how to make authentic Japanese sushi in your spare time.", PublishedDate = new DateTime(1991,6,12) },
                new Title() { Id = 8, TitleCode = "TC4203", TitleName = "Fifty Years in Buckingham Palace Kitchens", TitleType = "trad_cook   ", PublisherId = 2, PublisherCode = "0877", Price = 11.95m,  Royalty = 14,  YearToDateSales = 15096, Notes = "More anecdotes from the Queen's favorite cook describing life among English royalty. Recipes, techniques, tender vignettes.", PublishedDate = new DateTime(1991,6,12) },
                new Title() { Id = 9, TitleCode = "PC1035", TitleName = "But Is It User Friendly?", TitleType = "popular_comp", PublisherId = 3, PublisherCode = "1389", Price = 22.95m,  Royalty = 16,  YearToDateSales = 8780, Notes = "A survey of software for the naive user, focusing on the 'friendliness' of each.", PublishedDate = new DateTime(1991,6,30) },
                new Title() { Id = 10, TitleCode = "BU2075", TitleName = "You Can Combat Computer Stress!", TitleType = "business    ", PublisherId = 1, PublisherCode = "0736", Price = 2.99m,  Royalty = 24,  YearToDateSales = 18722, Notes = "The latest medical and psychological techniques for living with the electronic office. Easy-to-understand explanations.", PublishedDate = new DateTime(1991,6,30) },
                new Title() { Id = 11, TitleCode = "PS2091", TitleName = "Is Anger the Enemy?", TitleType = "psychology  ", PublisherId = 1, PublisherCode = "0736", Price = 10.95m,  Royalty = 12,  YearToDateSales = 2045, Notes = "Carefully researched study of the effects of strong emotions on the body. Metabolic charts included.", PublishedDate = new DateTime(1991,6,15) },
                new Title() { Id = 12, TitleCode = "PS2106", TitleName = "Life Without Fear", TitleType = "psychology  ", PublisherId = 1, PublisherCode = "0736", Price = 7.00m,  Royalty = 10,  YearToDateSales = 111, Notes = "New exercise, meditation, and nutritional techniques that can reduce the shock of daily interactions. Popular audience. Sample menus included, exercise video available separately.", PublishedDate = new DateTime(1991,10,5) },
                new Title() { Id = 13, TitleCode = "MC3021", TitleName = "The Gourmet Microwave", TitleType = "mod_cook    ", PublisherId = 2, PublisherCode = "0877", Price = 2.99m,  Royalty = 24,  YearToDateSales = 22246, Notes = "Traditional French gourmet recipes adapted for modern microwave cooking.", PublishedDate = new DateTime(1991,6,18) },
                new Title() { Id = 14, TitleCode = "TC3218", TitleName = "Onions, Leeks, and Garlic: Cooking Secrets of the Mediterranean", TitleType = "trad_cook   ", PublisherId = 2, PublisherCode = "0877", Price = 20.95m,  Royalty = 10,  YearToDateSales = 375, Notes = "Profusely illustrated in color, this makes a wonderful gift book for a cuisine-oriented friend.", PublishedDate = new DateTime(1991,10,21) },
                new Title() { Id = 15, TitleCode = "MC3026", TitleName = "The Psychology of Computer Cooking", TitleType = "trad_cook   ", PublisherId = 2, PublisherCode = "0877", Price = 19.99m,  Royalty = 10,  YearToDateSales = 375, Notes = "", PublishedDate = new DateTime(1996,5,15) },
                new Title() { Id = 16, TitleCode = "BU7832", TitleName = "Straight Talk About Computers", TitleType = "business    ", PublisherId = 3, PublisherCode = "1389", Price = 19.99m,  Royalty = 10,  YearToDateSales = 4095, Notes = "Annotated analysis of what computers can do for you: a no-hype guide for the critical user.", PublishedDate = new DateTime(1991,6,22) },
                new Title() { Id = 17, TitleCode = "PS1372", TitleName = "Computer Phobic AND Non-Phobic Individuals: Behavior Variations", TitleType = "psychology  ", PublisherId = 2, PublisherCode = "0877", Price = 21.59m,  Royalty = 10,  YearToDateSales = 375, Notes = "A must for the specialist, this book examines the difference between those who hate and fear computers and those who don't.", PublishedDate = new DateTime(1991,10,21) },
                new Title() { Id = 18, TitleCode = "PC9999", TitleName = "Net Etiquette", TitleType = "popular_comp", PublisherId = 3, PublisherCode = "1389", Price = 15.95m,  Royalty = 9,  YearToDateSales = 120, Notes = "A must-read for computer conferencing.", PublishedDate = new DateTime(1985,7,20) }
            });

            PubsDbContext.SaveChanges();
        }

        #endregion Private Methods
    }
}
