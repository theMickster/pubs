using FluentAssertions;
using FluentAssertions.Execution;
using Pubs.CoreDomain.Entities;
using Pubs.Infrastructure.Persistence.Repositories;
using Pubs.SharedKernel.Tests.Constants;
using Pubs.UnitTests.Persistence.Setup;
using Pubs.UnitTests.Persistence.Setup.Fixtures;
using System;
using Xunit;

namespace Pubs.UnitTests.Persistence.Repositories
{
    [Collection(FixtureCollections.PubsInMemoryRepositoryCollection)]
    public class AuthorRepositoryTests : PersistenceUnitTestBase
    {
        private readonly AuthorRepository _repository;
        private readonly PubsContextInMemoryDatabaseFixture _fixture;

        public AuthorRepositoryTests(PubsContextInMemoryDatabaseFixture fixture)
        {
            _repository = new AuthorRepository(fixture.PubsDbContext);
            _fixture = fixture;
        }

        /// <summary>
        /// Unit test to cover asynchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void async_crud_process_succeeds()
        {
            var entityId = 787;
            var entity = new Author
            {
                Id = entityId
                ,AuthorCode = "ABC-12345"
                ,FirstName = "Unit"
                ,LastName = "Test"
                ,PhoneNumber = "3607259465"
                ,Address = "549 SW Olympic Ave"
                ,City = "Lacey"
                ,State = "WA"
                ,ZipCode = "98503"
                ,Contract = false
            };

            var savedEntity = _repository.AddAsync(entity).Result;
            var updatedEntity = _repository.GetByIdAsync(entityId).Result;

            using (new AssertionScope())
            {
                savedEntity.Should().NotBeNull();
                savedEntity.Id.Should().Be(entityId);
                savedEntity.FirstName.Should().Be("Unit");
                savedEntity.PhoneNumber.Should().Be("3607259465");
                savedEntity.Contract.Should().BeFalse();
                savedEntity.AuthorCode.Should().Be("ABC-12345");

                updatedEntity.Should().NotBeNull();
                updatedEntity.Id.Should().Be(entityId);
                updatedEntity.FirstName.Should().Be("Unit");
                updatedEntity.PhoneNumber.Should().Be("3607259465");
                updatedEntity.Contract.Should().BeFalse();
                updatedEntity.AuthorCode.Should().Be("ABC-12345");

                updatedEntity.FirstName = "UnitUnit";
                updatedEntity.LastName = "TestTest";
                updatedEntity.Contract = true;

                _ = _repository.UpdateAsync(updatedEntity);

                updatedEntity = _repository.GetByIdAsync(entityId).Result;
                updatedEntity.FirstName.Should().Be("UnitUnit");
                updatedEntity.LastName.Should().Be("TestTest");
                updatedEntity.Contract.Should().BeTrue();
                updatedEntity.AuthorCode.Should().Be("ABC-12345");

                _ = _repository.DeleteAsync(updatedEntity);
                _repository.GetByIdAsync(entityId).Result.Should().BeNull();
            }
        }

        /// <summary>
        /// Unit test to cover asynchronous Create, Read, Update, and Delete operations. 
        /// </summary>
        [Fact]
        public void crud_process_succeeds()
        {
            var entityId = 797;
            var entity = new Author
            {
                Id = entityId
                ,AuthorCode = "ABC-54321"
                ,FirstName = "Unit"
                ,LastName = "Test"
                ,PhoneNumber = "3607259465"
                ,Address = "549 SW Olympic Ave"
                ,City = "Lacey"
                ,State = "WA"
                ,ZipCode = "98503"
                ,Contract = false
            };

            var savedEntity = _repository.Add(entity);
            var updatedEntity = _repository.GetById(entityId);

            using (new AssertionScope())
            {
                savedEntity.Should().NotBeNull();
                savedEntity.Id.Should().Be(entityId);
                savedEntity.FirstName.Should().Be("Unit");
                savedEntity.PhoneNumber.Should().Be("3607259465");
                savedEntity.Contract.Should().BeFalse();
                savedEntity.AuthorCode.Should().Be("ABC-54321");

                updatedEntity.Should().NotBeNull();
                updatedEntity.Id.Should().Be(entityId);
                updatedEntity.FirstName.Should().Be("Unit");
                updatedEntity.PhoneNumber.Should().Be("3607259465");
                updatedEntity.Contract.Should().BeFalse();
                updatedEntity.AuthorCode.Should().Be("ABC-54321");

                updatedEntity.FirstName = "UnitUnit";
                updatedEntity.LastName = "TestTest";
                updatedEntity.Contract = true;

                _repository.Update(updatedEntity);

                updatedEntity = _repository.GetById(entityId);
                updatedEntity.FirstName.Should().Be("UnitUnit");
                updatedEntity.LastName.Should().Be("TestTest");
                updatedEntity.Contract.Should().BeTrue();

                _repository.Delete(updatedEntity);
                _repository.GetById(entityId).Should().BeNull();
            }
        }

        [Fact]
        public void is_author_code_in_use_throws_correct_exception()
        {
            using (new AssertionScope())
            {
                ((Action)(() => _repository.IsAuthorCodeInUse(null)))
                    .Should().Throw<ArgumentException>()
                    .And.ParamName.Should().Be("authorCode");

                ((Action)(() => _repository.IsAuthorCodeInUse(string.Empty)))
                        .Should().Throw<ArgumentException>()
                        .And.ParamName.Should().Be("authorCode");

                ((Action)(() => _repository.IsAuthorCodeInUse("       ")))
                        .Should().Throw<ArgumentException>()
                        .And.ParamName.Should().Be("authorCode");
            }
        }

        [Fact]
        public void is_author_code_in_use_succeeds()
        {
            _repository.IsAuthorCodeInUse("012-34-5678").Should().BeFalse();
            _repository.IsAuthorCodeInUse("213-46-8915").Should().BeTrue();

        }

        [Fact]
        public void is_author_valid_succeeds()
        {
            using (new AssertionScope())
            {
                _repository.IsAuthorValid(-10).Should().BeFalse();
                _repository.IsAuthorValid(1000).Should().BeFalse();
                _repository.IsAuthorValid(1).Should().BeTrue();
                _repository.IsAuthorValid(2).Should().BeTrue();
                _repository.IsAuthorValid(5).Should().BeTrue();

            }
        }

        [Fact]
        public void get_titles_for_invalid_author_succeeds()
        {
            _repository.GetTitlesForAuthorAsync(1000).Result.Should().BeNullOrEmpty();
            _repository.GetTitlesForAuthorAsync(999).Result.Should().BeNullOrEmpty();
            _repository.GetTitlesForAuthorAsync(2).Result.Should().NotBeNullOrEmpty();
            _repository.GetTitlesForAuthorAsync(4).Result.Should().NotBeNullOrEmpty();

        }
    }
}
