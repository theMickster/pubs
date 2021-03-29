using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.SharedKernel.Tests.Constants;
using Pubs.UnitTests.Setup;
using Pubs.UnitTests.Setup.Fixtures;
using Xunit;

namespace Pubs.UnitTests.Infrastructure.Repositories
{
    [Collection(FixtureCollections.PubsInMemoryRepositoryCollection)]
    public class ApplicationRoleRepositoryTests : UnitTestBase
    {
        private readonly ApplicationRoleRepository _repository;

        public ApplicationRoleRepositoryTests(PubsContextInMemoryDatabaseFixture fixture)
        {
            _repository = new ApplicationRoleRepository(fixture.PubsDbContext);
        }

        /// <summary>
        /// Unit test to cover synchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void role_crud_process_succeeds()
        {
            var applicationRole = new ApplicationRole
            {
                Id = 99999,
                RoleName = "MyTestRoleGoesHere"
            };

            var savedRole = _repository.Add(applicationRole);
            var updatedRole = _repository.GetById(savedRole.Id);

            using (new AssertionScope())
            {
                savedRole.Should().NotBeNull();
                savedRole.Id.Should().Be(99999);
                savedRole.RoleName.Should().Be("MyTestRoleGoesHere");
                updatedRole.Id.Should().Be(savedRole.Id);

                updatedRole.RoleName = "MyNewTestRoleGoesHere";
                _repository.Update(updatedRole);

                updatedRole = _repository.GetById(savedRole.Id);
                updatedRole.RoleName.Should().Be("MyNewTestRoleGoesHere");

                _repository.Delete(updatedRole);
                _repository.GetById(savedRole.Id).Should().BeNull();
            }
        }

        /// <summary>
        /// Unit test to cover asynchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void role_async_crud_process_succeeds()
        {

            var applicationRole = new ApplicationRole
            {
                Id = 77777,
                RoleName = "MyAsyncTestRoleGoesHere"
            };

            var savedRole = _repository.AddAsync(applicationRole).Result;
            var updatedRole = _repository.GetByIdAsync(savedRole.Id).Result;


            using (new AssertionScope())
            {
                savedRole.Should().NotBeNull();
                savedRole.Id.Should().Be(77777);
                savedRole.RoleName.Should().Be("MyAsyncTestRoleGoesHere");
                updatedRole.Id.Should().Be(savedRole.Id);

                updatedRole.RoleName = "MyNewTestRoleGoesHere";
                _ = _repository.UpdateAsync(updatedRole);
                updatedRole = _repository.GetByIdAsync(savedRole.Id).Result;
                updatedRole.RoleName.Should().Be("MyNewTestRoleGoesHere");

                _ = _repository.DeleteAsync(updatedRole);
                _repository.GetByIdAsync(savedRole.Id).Result.Should().BeNull();
            }
        }
    }
}
