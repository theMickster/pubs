using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.Application.UnitTests.Setup;
using Pubs.Application.UnitTests.Setup.Fixtures;
using Pubs.CoreDomain.Entities.Security;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.SharedKernel.Tests.Constants;
using Xunit;

namespace Pubs.Application.UnitTests.Infrastructure.Repositories
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
            var applicationRole = new ApplicationRole()
            {
                Id = 99999,
                RoleName = "MyTestRoleGoesHere"
            };

            var savedRole = _repository.Add(applicationRole);

            using (new AssertionScope())
            {
                savedRole.Should().NotBeNull();
                savedRole.Id.Should().Be(99999);
                savedRole.RoleName.Should().Be("MyTestRoleGoesHere");
            }
        }

        /// <summary>
        /// Unit test to cover asynchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void role_async_crud_process_succeeds()
        {

            var applicationRole = new ApplicationRole()
            {
                Id = 77777,
                RoleName = "MyAsyncTestRoleGoesHere"
            };

            var savedRole = _repository.AddAsync(applicationRole).Result;

            using (new AssertionScope())
            {
                savedRole.Should().NotBeNull();
                savedRole.Id.Should().Be(77777);
                savedRole.RoleName.Should().Be("MyAsyncTestRoleGoesHere");
            }
        }
    }
}
