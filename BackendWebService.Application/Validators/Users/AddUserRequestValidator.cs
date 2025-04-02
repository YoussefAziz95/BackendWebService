using Application.DTOs.User;
using FluentValidation;

namespace Application.Validators.Users
{
    /// <summary>
    /// Validator for adding user requests.
    /// </summary>
    public sealed class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddUserRequestValidator"/> class.
        /// </summary>
        public AddUserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required")
                .Length(3, 20)
                .WithMessage("First Name length must be between 3 and 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required")
                .Length(3, 20)
                .WithMessage("Last Name length must be between 3 and 50 characters");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .Length(3, 20)
                .WithMessage("Username length must be between 3 and 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto Address is required")
                .EmailAddress()
                .WithMessage("Invalid EmailDto Address.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(x => x.Roles)
                .Must(arr => arr is not null && arr.Any())
                .WithMessage("Please Choose at least one role.");
        }
    }
}
