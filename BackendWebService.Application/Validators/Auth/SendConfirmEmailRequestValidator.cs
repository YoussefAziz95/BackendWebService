using Application.DTOs.Auths;
using FluentValidation;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for validating the properties of a SendConfirmEmailRequest DTO.
    /// </summary>
    public sealed class SendConfirmEmailRequestValidator : AbstractValidator<SendConfirmEmailRequest>
    {
        /// <summary>
        /// Initializes a new instance of the SendConfirmEmailRequestValidator class.
        /// </summary>
        public SendConfirmEmailRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");
        }
    }
}
