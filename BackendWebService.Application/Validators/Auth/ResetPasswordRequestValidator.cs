using Application.DTOs.Auth.Request;
using FluentValidation;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for the <see cref="ResetPasswordRequest"/> class.
    /// </summary>
    public sealed class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordRequestValidator"/> class.
        /// </summary>
        public ResetPasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Token)
                .NotEmpty()
                .WithMessage("Token is required.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
