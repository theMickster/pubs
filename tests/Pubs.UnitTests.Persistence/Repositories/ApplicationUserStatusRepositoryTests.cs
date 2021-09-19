using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.SharedKernel.Tests.Constants;
using Pubs.UnitTests.Persistence.Setup;
using Pubs.UnitTests.Persistence.Setup.Fixtures;
using Xunit;

namespace Pubs.UnitTests.Persistence.Repositories
{
    [Collection(FixtureCollections.PubsInMemoryRepositoryCollection)]
    public class ApplicationUserStatusRepositoryTests : PersistenceUnitTestBase
    {
        private readonly PubsContextInMemoryDatabaseFixture _fixture;
        private readonly ApplicationUserStatusRepository _repository;

        public ApplicationUserStatusRepositoryTests(PubsContextInMemoryDatabaseFixture fixture)
        {
            _fixture = fixture;
            _repository = new ApplicationUserStatusRepository(fixture.PubsDbContext);
        }

        /// <summary>
        /// Unit test to cover asynchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void role_async_crud_process_succeeds()
        {
            var entityId = 777;
            var entity = new ApplicationUserStatus()
            {
                Id = entityId,
                StatusName = "Hello World",
                StatusAbbreviation = "H"
            };

            var savedEntity = _repository.AddAsync(entity).Result;
            var updatedEntity = _repository.GetByIdAsync(entityId).Result;


            using (new AssertionScope())
            {
                savedEntity.Should().NotBeNull();
                savedEntity.Id.Should().Be(entityId);
                savedEntity.StatusName.Should().Be("Hello World");
                savedEntity.StatusAbbreviation.Should().Be("H");

                updatedEntity.Id.Should().Be(entityId);

                updatedEntity.StatusName = "Hello-World";
                updatedEntity.StatusAbbreviation = "W";

                _ = _repository.UpdateAsync(updatedEntity);
                updatedEntity = _repository.GetByIdAsync(entityId).Result;
                updatedEntity.StatusName.Should().Be("Hello-World");
                updatedEntity.StatusAbbreviation.Should().Be("W");

                _ = _repository.DeleteAsync(updatedEntity);
                _repository.GetByIdAsync(entityId).Result.Should().BeNull();
            }

        }
    }
}
