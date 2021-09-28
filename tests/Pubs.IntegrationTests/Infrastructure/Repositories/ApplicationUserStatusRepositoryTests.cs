using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Pubs.CoreDomain.Enums;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.IntegrationTests.Setup;
using Xunit;

namespace Pubs.IntegrationTests.Infrastructure.Repositories
{
    public class ApplicationUserStatusRepositoryTests : IntegrationTestBase
    {
        private readonly ApplicationUserStatusRepository _repository;
        public ApplicationUserStatusRepositoryTests()
        {
            _repository = new ApplicationUserStatusRepository(Context);
        }

        [Fact]
        public void get_list_all_succeeds()
        {
            var results = _repository.ListAll();

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();
                results?.Count.Should().Be(3);
            }
        }

        [Fact]
        public void get_list_all_async_succeeds()
        {
            var results = _repository.ListAllAsync().Result;

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();
                results?.Count.Should().Be(3);
            }
        }

        [Fact]
        public void get_by_id_succeeds()
        {
            var result = _repository.GetById((int)ApplicationUserStatusEnum.Active);

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.StatusAbbreviation.Should().Be("A");
            }
        }


        [Fact]
        public void get_by_id_async_succeeds()
        {
            var result = _repository.GetByIdAsync((int)ApplicationUserStatusEnum.Inactive).Result;
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.StatusAbbreviation.Should().Be("I");
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
