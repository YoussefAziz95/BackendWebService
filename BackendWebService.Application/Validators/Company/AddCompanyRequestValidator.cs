using FluentValidation;
using Application.DTOs.Companies;

namespace Application.Validators.Company
{
    /// <summary>
    /// Validator for validating the properties of an AddCompanyRequest DTO.
    /// </summary>
    public sealed class AddCompanyRequestValidator : AbstractValidator<AddCompanyRequest>
    {
        /// <summary>
        /// Initializes a new instance of the AddCompanyRequestValidator class.
        /// </summary>
        public AddCompanyRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.TaxNo)
                .NotEmpty()
                .WithMessage("Tax Number is required")
                .MaximumLength(11)
                .WithMessage("Tax Number length must be less than 11 numbers");
        }
    }
}
