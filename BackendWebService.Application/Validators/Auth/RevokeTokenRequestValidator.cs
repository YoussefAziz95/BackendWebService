using Application.DTOs.Auth.Request;

using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for RevokeTokenRequest DTO.
    /// </summary>
    public sealed class RevokeTokenRequestValidator : AbstractValidator<RevokeTokenRequest>
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RevokeTokenRequestValidator"/> class.
        /// </summary>
        /// <param name="userManager">The user manager for accessing user-related operations.</param>
        public RevokeTokenRequestValidator(UserManager<User> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}
