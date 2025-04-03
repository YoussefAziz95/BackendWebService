using Application.DTOs.Roles;
using FluentValidation;

namespace Application.Validators.Roles
{
    /// <summary>
    /// Validator for creating role requests.
    /// </summary>
    public sealed class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleRequestValidator"/> class.
        /// </summary>
        public CreateRoleRequestValidator()
        {
            // Validate Name
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("Roles Name is Required.")
                .Length(3, 20).WithMessage("Roles name must be between 3 and 20 characters.");
        }
    }
}
