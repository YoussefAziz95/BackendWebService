using Application.DTOs.Auth.Request;
using FluentValidation;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for login requests.
    /// </summary>
    public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRequestValidator"/> class.
        /// </summary>
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
