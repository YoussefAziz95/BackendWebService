using Application.DTOs.Role;
using FluentValidation;

namespace Application.Validators.Roles
{
    /// <summary>
    /// Validator for validating the properties of an AddRoleToUserRequest DTO.
    /// </summary>
    public sealed class AddRoleToUserRequestValidator : AbstractValidator<AddRoleToUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the AddRoleToUserRequestValidator class.
        /// </summary>
        public AddRoleToUserRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Customer Id is required.");

            RuleFor(x => x.Role)
                .NotNull()
                .NotEmpty()
                .WithMessage("Role Name is Required.")
                .Length(3, 20)
                .WithMessage("Role name must be between 3 and 20 characters");
        }
    }
}
