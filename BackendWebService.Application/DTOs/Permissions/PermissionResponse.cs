using Application.DTOs.Roles;
using System.Collections.Generic;
using System.Security.Claims;

namespace Application.DTOs.Permission
{
    /// <summary>
    /// Represents a response model for permissions.
    /// </summary>
    public class PermissionResponse
    {
        /// <summary>
        /// Gets or sets the identifier of the role associated with the permission.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the permission.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of claims associated with the permission.
        /// </summary>
        public List<ClaimResponse>? Claims { get; set; }
    }
}
