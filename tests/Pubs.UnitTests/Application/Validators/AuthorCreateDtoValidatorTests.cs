using FluentAssertions;
using FluentAssertions.Execution;
using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using Pubs.Application.DTOs;
using Pubs.Application.Interfaces.Repositories;
using Pubs.Application.Validators.Authors;
using Pubs.SharedKernel.Utilities;
using Pubs.UnitTests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Pubs.UnitTests.Application.Validators
{
    public class AuthorCreateDtoValidatorTests : UnitTestBase
    {
        private readonly AuthorCreateDtoValidator _validator;
        private readonly Mock<IAuthorRepository> _mockRepository;

        public AuthorCreateDtoValidatorTests()
        {
            _mockRepository = new Mock<IAuthorRepository>();
            _validator = new AuthorCreateDtoValidator(_mockRepository.Object);
        }

        [Fact]
        public void validator_succeeds_when_all_data_is_valid()
        {
            _mockRepository.Setup(x => x.IsAuthorCodeInUse(It.IsAny<string>())).Returns(false);

            var sut = new AuthorCreateDto()
            {
                FirstName = "Mickey",
                LastName = "Mantle",
                AuthorCode = "123-45-6789",
                PhoneNumber = "360-549-5484"
            };

            var result = _validator.TestValidate(sut);

            using (new AssertionScope())
            {
                result.ShouldNotHaveAnyValidationErrors();
                _validator.HasErrors.Should().BeFalse();
                _validator.GetErrors().Should().NotBeNull();
                _validator.GetAllErrors().Should().BeEmpty();
                _validator.GetAllWarnings().Should().BeEmpty();
                (_validator.GetErrors("AuthorCode") as List<string>).Should().BeEmpty();
            }

        }

        [Fact]
        public void validator_fails_when_author_code_is_null()
        {
            var sut = new AuthorCreateDto()
            {
                FirstName = "Mickey",
                LastName = "Mantle",
                AuthorCode = null,
                PhoneNumber = "360-549-5484"
            };

            var result = _validator.TestValidate(sut);
            _ = _validator.ValidateProperties(sut);

            using (new AssertionScope())
            {
                result.ShouldHaveValidationErrorFor(x => x.AuthorCode)
                .WithErrorMessage("Author Code cannot be null")
                .WithSeverity(Severity.Error)
                .WithErrorCode("A-Rule-001");


                _validator.HasErrors.Should().BeTrue();
                _validator.GetErrors().Should().NotBeNull();
                _validator.GetAllErrors().Should().NotBeEmpty();
                _validator.GetAllWarnings().Should().BeEmpty();

                (_validator.GetErrors("AuthorCode") as List<string>).Should().NotBeEmpty();
                (_validator.GetErrors() as List<string>).Should().NotBeEmpty();
                (_validator.GetErrors("FirstName") as List<string>).Should().BeEmpty();

                (_validator.GetWarnings("FirstName") as List<string>).Should().BeEmpty();
                (_validator.GetWarnings() as List<string>).Should().BeEmpty();

                ((Action)(() => _validator.GetErrors("AuthorId")))
                    .Should().Throw<ArgumentException>()
                    .And.Message.Should().Contain("Property name AuthorId does not exist in");

                ((Action)(() => _validator.GetWarnings("AuthorId")))
                    .Should().Throw<ArgumentException>()
                    .And.Message.Should().Contain("Property name AuthorId does not exist in");

                _validator.Errors.Count.Should().BeGreaterThan(0);
            }
        }

        [Fact]
        public void validator_fails_when_author_code_is_empty()
        {
            var sut = new AuthorCreateDto()
            {
                FirstName = "Mickey",
                LastName = "Mantle",
                AuthorCode = string.Empty,
                PhoneNumber = "360-549-5484"
            };

            var result = _validator.TestValidate(sut);

            result.ShouldHaveValidationErrorFor(x => x.AuthorCode)
                .WithErrorMessage("Author Code cannot be empty")
                .WithSeverity(Severity.Error)
                .WithErrorCode("A-Rule-002");
        }

        [Fact]
        public void validator_fails_when_author_code_is_too_long()
        {
            var sut = new AuthorCreateDto()
            {
                FirstName = "Mickey",
                LastName = "Mantle",
                AuthorCode = StringGenerator.GenerateRandomString(12),
                PhoneNumber = "360-549-5484"
            };

            var result = _validator.TestValidate(sut);

            result.ShouldHaveValidationErrorFor(x => x.AuthorCode)
                .WithErrorMessage("Author Code must be exactly 11 characters")
                .WithSeverity(Severity.Error)
                .WithErrorCode("A-Rule-003");
        }

        [Fact]
        public void validator_fails_when_author_code_is_wrong_format()
        {
            var sut = new AuthorCreateDto()
            {
                FirstName = "Mickey",
                LastName = "Mantle",
                AuthorCode = "ABC-12-3456",
                PhoneNumber = "360-549-5484"
            };

            var result = _validator.TestValidate(sut);

            result.ShouldHaveValidationErrorFor(x => x.AuthorCode)
                .WithErrorMessage("Author code must be in the format of ###-##-####")
                .WithSeverity(Severity.Error)
                .WithErrorCode("A-Rule-004");
        }

        [Fact]
        public void validator_fails_when_author_code_is_in_use()
        {
            _mockRepository.Setup(x => x.IsAuthorCodeInUse(It.IsAny<string>())).Returns(true);

            var sut = new AuthorCreateDto()
            {
                FirstName = "Derek",
                LastName = "Jeter",
                AuthorCode = "541-12-3456",
                PhoneNumber = "360-548-3215"
            };

            var result = _validator.TestValidate(sut);

            result.ShouldHaveValidationErrorFor(x => x.AuthorCode)
                .WithErrorMessage("Author code must be unique and not already in use")
                .WithSeverity(Severity.Error)
                .WithErrorCode("A-Rule-005");
        }
    }
}
