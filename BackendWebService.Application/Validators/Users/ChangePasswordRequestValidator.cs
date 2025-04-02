using Application.DTOs.User;
using FluentValidation;

namespace Application.Validators.Users
{
    /// <summary>
    /// Validator for validating requests to change a user's password.
    /// </summary>
    public sealed class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordRequestValidator"/> class.
        /// </summary>
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.OldPassword)
               .NotEmpty()
               .WithMessage("Password is required.");

            RuleFor(x => x.NewPassword)
              .NotEmpty()
              .WithMessage("Password is required.");
        }
    }
}
