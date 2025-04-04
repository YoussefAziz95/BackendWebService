using Application.DTOs.Auths;
using FluentValidation;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for the <see cref="ConfirmOtpRequest"/> class.
    /// </summary>
    public sealed class ConfirmOtpRequestValidator : AbstractValidator<ConfirmOtpRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmOtpRequestValidator"/> class.
        /// </summary>
        public ConfirmOtpRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Otp)
                .NotEmpty()
                .WithMessage("Token is required.");
        }
    }
}
