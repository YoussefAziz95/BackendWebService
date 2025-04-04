using Application.Validators.Common;

namespace Application.DTOs.Roles
{
    /// <summary>
    /// Represents a request to add a role to a user.
    /// </summary>
    public class AddRoleToUserRequest : BaseValidationModel<AddRoleToUserRequest>
    {
        /// <summary>
        /// Gets or sets the identifier of the user to whom the role will be added.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the role to be added to the user.
        /// </summary>
        public required string Role { get; set; }
    }
}
