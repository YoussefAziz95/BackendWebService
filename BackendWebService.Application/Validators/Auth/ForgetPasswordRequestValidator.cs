using Application.DTOs.Auths;
using Application.Profiles;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Validators.Auth
{
    /// <summary>
    /// Validator for ForgetPasswordRequest DTO.
    /// </summary>
    public sealed class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>, ICreateMapper<User>
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForgetPasswordRequestValidator"/> class.
        /// </summary>
        /// <param name="userManager">The user manager for accessing user-related operations.</param>
        public ForgetPasswordRequestValidator(UserManager<User> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("EmailDto address is required.")
                .EmailAddress()
                .WithMessage("Invalid EmailDto address.")
                .MustAsync(EmailExists)
                .WithMessage("This EmailDto address is not registered.");
        }

        /// <summary>
        /// Checks if the provided email address exists in the user database.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean indicating whether the email exists.</returns>
        private async Task<bool> EmailExists(string email, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}
