using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.IntegrationTests.Setup;
using Xunit;

namespace Pubs.IntegrationTests.Infrastructure.Repositories
{
    public class AuthorRepositoryTests : IntegrationTestBase
    {
        private readonly AuthorRepository _repository;

        public AuthorRepositoryTests()
        {
            _repository = new AuthorRepository(Context);
        }

        [Fact]
        public void get_author_list_async_succeeds()
        {
            var result = _repository.GetAuthorsAsync().Result;

            using (new AssertionScope())
            {
                result.Should().NotBeNullOrEmpty();
                result.Count.Should().BeGreaterOrEqualTo(23);
            }
        }

        [Fact]
        public void get_author_by_id_asyc_succeeds()
        {
            var result = _repository.GetAuthorAsync(id: 5).Result;

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Id.Should().Be(5);
            }
        }

        [Fact]
        public void get_by_id_succeeds()
        {
            var result = _repository.GetById(id: 7);

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Id.Should().Be(7);
            }
        }

        [Fact]
        public void get_by_id_async_succeeds()
        {
            var result = _repository.GetByIdAsync(id: 8).Result;

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Id.Should().Be(8);
            }
        }

        [Fact]
        public void get_list_all_succeeds()
        {
            var results = _repository.ListAll();

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();
                results?.Count.Should().BeGreaterOrEqualTo(23);
            }
        }


        [Fact]
        public void get_list_all_async_succeeds()
        {
            var results = _repository.ListAllAsync().Result;

            using (new AssertionScope())
            {
                results.Should().NotBeNullOrEmpty();
                results?.Count.Should().BeGreaterOrEqualTo(23);
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
