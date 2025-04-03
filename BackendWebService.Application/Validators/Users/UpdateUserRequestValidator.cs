using Application.DTOs.Users;
using FluentValidation;

namespace Application.Validators.Users
{
    /// <summary>
    /// Validator for validating requests to update a user.
    /// </summary>
    public sealed class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserRequestValidator"/> class.
        /// </summary>
        public UpdateUserRequestValidator()
        {
            When(x => !string.IsNullOrEmpty(x.FirstName), () =>
            {
                RuleFor(x => x.FirstName)
                    .NotEmpty()
                    .WithMessage("First Name is required")
                    .Length(3, 20)
                    .WithMessage("First Name length must be between 3 and 50 characters");
            });

            When(x => !string.IsNullOrEmpty(x.LastName), () =>
            {
                RuleFor(x => x.LastName)
                    .NotEmpty()
                    .WithMessage("Last Name is required")
                    .Length(3, 20)
                    .WithMessage("Last Name length must be between 3 and 50 characters");
            });

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("EmailDto Address is required")
                    .EmailAddress()
                    .WithMessage("Invalid EmailDto Address.");
            });
        }
    }
}
