using Application.DTOs;
using FluentValidation;

namespace Application.Validators.Users
{
    /// <summary>
    /// Validator for adding user requests.
    /// </summary>
    public sealed class CreateUserWithPasswordRequestValidator : AbstractValidator<CreateUserWithPasswordRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserWithPasswordRequestValidator"/> class.
        /// </summary>
        public CreateUserWithPasswordRequestValidator()
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

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("UserName is required")
                .Length(3, 20)
                .WithMessage("UserName length must be between 3 and 50 characters");


            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(x => x.MainRole)
                .NotEmpty()
                .WithMessage("Please Choose at least one role.");
        }
    }
}
