using Microsoft.AspNetCore.Authorization;

namespace Application.Permissions
{
    /// <summary>
    /// Represents a requirement for a specific permission.
    /// </summary>
    public class PermissionRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Gets the permission required by this requirement.
        /// </summary>
        public string Permission { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionRequirement"/> class with the specified permission.
        /// </summary>
        /// <param name="permission">The permission required by this requirement.</param>
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
