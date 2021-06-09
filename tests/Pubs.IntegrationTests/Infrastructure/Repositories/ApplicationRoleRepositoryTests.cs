using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.IntegrationTests.Setup;
using Xunit;

namespace Pubs.IntegrationTests.Infrastructure.Repositories
{
    public class ApplicationRoleRepositoryTests : IntegrationTestBase
    {
        private readonly ApplicationRoleRepository _repository;
        public ApplicationRoleRepositoryTests()
        {
            _repository = new ApplicationRoleRepository(Context);
        }

        [Fact]
        public void get_list_all_succeeds()
        {
            var results = _repository.ListAll();

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();
                results?.Count.Should().Be(4);
            }
        }


        [Fact]
        public void get_list_all_async_succeeds()
        {
            var results = _repository.ListAllAsync().Result;

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();
                results?.Count.Should().Be(4);
            }
        }

        [Fact]
        public void get_db_entity_succeeds()
        {
            var results = _repository.ListAll();

            using (new AssertionScope())
            {
                foreach (var result in results)
                {
                    var entity = _repository.GetDbEntityEntry(result);
                    entity.Should().NotBeNull();
                    entity.State.Should().Be(EntityState.Unchanged);
                    entity.Entity.Id.Should().Be(result.Id);
                }
            }
        }
    }
}
