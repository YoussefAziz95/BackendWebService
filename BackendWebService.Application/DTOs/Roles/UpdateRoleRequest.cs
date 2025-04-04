using Application.Validators.Common;
using BackendWebService.Application.Profiles;
using Domain;
using System.Collections.Generic;

namespace Application.DTOs.Roles
{
    /// <summary>
    /// Represents a request model for updating a role.
    /// </summary>
    public class UpdateRoleRequest : BaseValidationModel<UpdateRoleRequest>, ICreateMapper<Role>
    {
        /// <summary>
        /// Gets or sets the ID of the role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the list of claims associated with the role.
        /// </summary>
        public List<string> Claims { get; set; }
    }
}
