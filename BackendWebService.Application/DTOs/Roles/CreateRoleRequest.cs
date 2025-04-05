using Application.Validators.Common;
using Application.Profiles;
using Domain;
using System.Collections.Generic;

namespace Application.DTOs.Roles
{
    /// <summary>
    /// Represents a request model for creating a role.
    /// </summary>
    public class CreateRoleRequest : BaseValidationModel<CreateRoleRequest>, ICreateMapper<Role>
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of claims associated with the role.
        /// </summary>
        public List<string> Claims { get; set; }
    }
}
