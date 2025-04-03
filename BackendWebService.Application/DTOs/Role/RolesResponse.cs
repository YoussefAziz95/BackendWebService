using Domain.Enums;
using Domain;
using BackendWebService.Application.Profiles;
using System;

namespace Application.DTOs.Roles
{
    /// <summary>
    /// Represents a response containing information about a role.
    /// </summary>
    public class RolesResponse : ICreateMapper<Role>
    {
        /// <summary>
        /// Gets or sets the identifier of the role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the role is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date when the role was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the role was last updated, if applicable.
        /// </summary>
        public DateTime? UpdateDate { get; set; }
    }
}
