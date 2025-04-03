using Application.DTOs.Common;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Validators.Common
{
    /// <summary>
    /// Validator for DeleteSuperPasswordRequest DTO.
    /// </summary>
    public sealed class DeleteSuperPasswordRequestValidator : AbstractValidator<DeleteSuperPasswordRequest>
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSuperPasswordRequestValidator"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public DeleteSuperPasswordRequestValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
            RuleFor(x => x.SuperPassword)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (password, cancellationToken) =>
                {
                    var user = await _userManager.FindByIdAsync("1");
                    if (user == null)
                        return false;

                    var result = await _userManager.CheckPasswordAsync(user, password);
                    return result;
                })
                .WithMessage("SuperPassword does not match the password.");
        }

        /// <summary>
        /// Validates the super password.
        /// </summary>
        /// <param name="superPassword">The super password.</param>
        /// <returns>A boolean indicating whether the super password is valid.</returns>
        private async Task<bool> ValidateSuperPassword(string superPassword)
        {
            var user = await _userManager.FindByIdAsync("1");
            if (user == null)
                return false;

            var result = await _userManager.CheckPasswordAsync(user, superPassword);
            _userManager.Dispose();
            return result;
        }
    }
}
