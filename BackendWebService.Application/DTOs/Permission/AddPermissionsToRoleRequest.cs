using Application.Validators.Common;

namespace Application.DTOs.Permission
{
    /// <summary>
    /// Represents a request to add permissions to a role.
    /// </summary>
    public class AddPermissionsToRoleRequest : BaseValidationModel<AddPermissionsToRoleRequest>
    {
        /// <summary>
        /// Gets or sets the identifier of the role to which permissions will be added.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the list of permissions (claims) to be added to the role.
        /// </summary>
        public required List<string> Claims { get; set; } = new List<string>();
    }
}
