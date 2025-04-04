using Application.DTOs.Auths;
using FluentValidation;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for supplier registration requests.
    /// </summary>
    public sealed class RegisterSupplierRequestValidator : AbstractValidator<RegisterSupplierRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterSupplierRequestValidator"/> class.
        /// </summary>
        public RegisterSupplierRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Suppliers name is required.")
                .Must(x => x != null && x.Any())
                .WithMessage("Suppliers name cannot be empty.");

            RuleFor(x => x.Country)
              .NotEmpty()
              .WithMessage("Country is required.");
            RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("City is required.");
            RuleFor(x => x.StreetAddress)
            .NotEmpty()
            .WithMessage("Street Address is required.");

            RuleFor(x => x.TaxNo)
                .NotEmpty()
                .WithMessage("Tax number is required.")
                .Matches(@"^\d+$")
                .WithMessage("Tax number must be numeric.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Phone)
                .Cascade(CascadeMode.Stop) // Stops at first failure
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^\d+$")
                .WithMessage("Phone number must be numeric.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Categories)
                .Must(categories => categories == null || categories.Any())
                .WithMessage("At least one category is required.")
                .When(x => x.Categories != null);
        }
    }
}
