using FluentValidation;
using Pubs.Application.DTOs;
using Pubs.Application.Interfaces.Repositories;
using Pubs.Application.Validators.Base;

namespace Pubs.Application.Validators.Authors
{
    public class AuthorCreateDtoValidator : FluentValidator<AuthorCreateDto>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorCreateDtoValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            /*****************************************************************************************************
             * Cascade through all validation errors until the validation process is complete.
             ****************************************************************************************************/
            CascadeMode = CascadeMode.Continue;

            RuleFor(a => a.AuthorCode)
                .NotNull().WithMessage("Author Code cannot be null").WithErrorCode("A-Rule-001")
                .NotEmpty().WithMessage("Author Code cannot be empty").WithErrorCode("A-Rule-002")
                .Length(11).WithMessage("Author Code must be exactly 11 characters").WithErrorCode("A-Rule-003")
                .Matches("[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]").WithMessage("Author code must be in the format of ###-##-####").WithErrorCode("A-Rule-004");

            RuleFor(a => new {a.AuthorCode })
                .Must(b => _authorRepository.IsAuthorCodeInUse(b.AuthorCode) == false )
                .WithMessage("Author code must be unique and not already in use")
                .WithErrorCode("A-Rule-005")
                .OverridePropertyName("AuthorCode");
            ;
        }
    }
}
