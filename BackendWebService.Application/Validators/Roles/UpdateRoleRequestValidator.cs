using Application.DTOs.Roles;
using FluentValidation;

namespace Application.Validators.Roles
{
    /// <summary>
    /// Validator for validating requests to update a role.
    /// </summary>
    public sealed class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRoleRequestValidator"/> class.
        /// </summary>
        public UpdateRoleRequestValidator()
        {
            RuleFor(x => x.Role)
               .NotNull()
               .NotEmpty()
               .WithMessage("Roles Name is Required.")
               .Length(3, 20)
               .WithMessage("Roles name must be between 3 and 20 character");
        }
    }
}
