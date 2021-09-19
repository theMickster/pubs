using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.SharedKernel.Tests.Constants;
using Pubs.UnitTests.Persistence.Setup;
using Pubs.UnitTests.Persistence.Setup.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Persistence.Repositories
{
    [Collection(FixtureCollections.PubsInMemoryRepositoryCollection)]
    public class ApplicationUserRepositoryTests : PersistenceUnitTestBase
    {
        private readonly ApplicationUserRepository _repository;
        private readonly PubsContextInMemoryDatabaseFixture _fixture;

        public ApplicationUserRepositoryTests(PubsContextInMemoryDatabaseFixture fixture)
        {
            _repository = new ApplicationUserRepository(fixture.PubsDbContext);
            _fixture = fixture;
        }

        /// <summary>
        /// Unit test to cover asynchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void async_crud_process_succeeds()
        {
            var entityId = 707;
            var userStatus = _fixture.PubsDbContext.ApplicationUserStatuses.FirstOrDefault(x => x.Id == 1001);

            var entity = new ApplicationUser(new DateTime(2021, 08, 15))
            {
                Id = entityId,
                UserName = "unit.test",
                UserPrincipalName = "user.test.001@contoso.com",
                FirstName = "User",
                MiddleName = "J.",
                LastName = "Test",
                EmailAddress = "user.j.test@contoso.com",                
                PhoneNumber = "3039876543"
            };

            entity.UpdateApplicationUserStatus(userStatus);

            var savedEntity = _repository.AddAsync(entity).Result;
            var updatedEntity = _repository.GetByIdAsync(entity.Id).Result;

            using (new AssertionScope())
            {
                savedEntity.Should().NotBeNull();
                savedEntity.Id.Should().Be(entityId);
                savedEntity.FirstName.Should().Be("User");
                savedEntity.PhoneNumber.Should().Be("3039876543");
                savedEntity.IsActive.Should().BeTrue();

                updatedEntity.Should().NotBeNull();
                updatedEntity.Id.Should().Be(entityId);
                updatedEntity.FirstName.Should().Be("User");
                updatedEntity.PhoneNumber.Should().Be("3039876543");


                updatedEntity.FirstName = "UnitUnit";
                updatedEntity.LastName = "LastName";

                _ = _repository.UpdateAsync(updatedEntity);

                updatedEntity = _repository.GetByIdAsync(updatedEntity.Id).Result;
                updatedEntity.FirstName.Should().Be("UnitUnit");
                updatedEntity.LastName.Should().Be("LastName");

                _ = _repository.DeleteAsync(updatedEntity);
                _repository.GetByIdAsync(entityId).Result.Should().BeNull();
            }


        }
    }
}
