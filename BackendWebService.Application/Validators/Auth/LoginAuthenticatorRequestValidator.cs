using Application.DTOs;
using FluentValidation;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for validating the properties of a LoginAuthenticatorRequest DTO.
    /// </summary>
    public sealed class LoginAuthenticatorRequestValidator : AbstractValidator<LoginAuthenticatorRequest>
    {
        /// <summary>
        /// Initializes a new instance of the LoginAuthenticatorRequestValidator class.
        /// </summary>
        public LoginAuthenticatorRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty()
                .WithMessage("UserInfo Id address is required.");

            RuleFor(x => x.AccessToken)
                .NotEmpty()
                .WithMessage("Access Token is required.");
        }
    }
}
