using Application.DTOs.Permission;
using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using System.Collections.Generic;

using Domain.Enums;
using Domain;
namespace Application.DTOs.Roles
{
    /// <summary>
    /// Represents a request model for updating a role.
    /// </summary>
    public class RoleResponse : BaseValidationModel<UpdateRoleRequest>, ICreateMapper<Role>
    {
        /// <summary>
        /// Gets or sets the ID of the role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of claims associated with the role.
        /// </summary>
        public List<ClaimResponse>? Claims { get; set; }
    }
}
