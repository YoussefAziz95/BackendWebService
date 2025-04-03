using FluentValidation;
using Application.DTOs.Companies.Request;

namespace Application.Validators.Company
{
    /// <summary>
    /// Validator for editing company requests.
    /// </summary>
    public sealed class EditCompanyRequestValidator : AbstractValidator<UpdateCompanyRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditCompanyRequestValidator"/> class.
        /// </summary>
        public EditCompanyRequestValidator()
        {
            // Validate Phone
            When(x => !string.IsNullOrEmpty(x.Phone), () =>
            {
                RuleFor(x => x.Phone)
                    .NotEmpty().WithMessage("Phone number is required.")
                    .MaximumLength(11).WithMessage("Phone number cannot exceed 11 characters.");
            });

            // Validate EmailDto
            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("EmailDto address is required.")
                    .EmailAddress().WithMessage("Invalid email address.");
            });

        }
    }
}
