using Application.DTOs.Auth.Request;
using FluentValidation;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for confirming email requests.
    /// </summary>
    public sealed class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmEmailRequestValidator"/> class.
        /// </summary>
        public ConfirmEmailRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Token)
                .NotEmpty()
                .WithMessage("Token is required.");
        }
    }
}
