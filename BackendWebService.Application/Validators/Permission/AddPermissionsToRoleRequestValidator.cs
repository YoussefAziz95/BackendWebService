using Application.DTOs.Permission;
using FluentValidation;

namespace Application.Validators.Permission
{
    /// <summary>
    /// Validator for validating requests to add permissions to a role.
    /// </summary>
    public sealed class AddPermissionsToRoleRequestValidator : AbstractValidator<AddPermissionsToRoleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddPermissionsToRoleRequestValidator"/> class.
        /// </summary>
        public AddPermissionsToRoleRequestValidator()
        {
            RuleFor(x => x.Claims)
                .Must(x => x != null && x.Count() > 0)
                .WithMessage("The list of permissions cannot be empty.");

            RuleForEach(x => x.Claims)
                .NotEmpty()
                .WithMessage("Permission must not be empty.")
                .Must(x => IsValidPermission(x))
                .WithMessage("Invalid Permission.");
        }

        /// <summary>
        /// Checks if the provided permission is valid.
        /// </summary>
        /// <param name="value">The permission value to validate.</param>
        /// <returns>True if the permission is valid; otherwise, false.</returns>
        private bool IsValidPermission(string value)
        {
            return typeof(Domain.Constants.PermissionConstants).GetFields()
                .Any(field => field.GetValue(null)?.ToString() == value);
        }
    }
}
