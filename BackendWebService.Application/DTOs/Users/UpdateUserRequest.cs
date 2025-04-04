using Application.Validators.Common;
using System.Collections.Generic;

namespace Application.DTOs.Users
{
    /// <summary>
    /// Represents a request model for updating a user.
    /// </summary>
    public class UpdateUserRequest : BaseValidationModel<UpdateUserRequest>
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user type.
        /// </summary>
        public string? MainRole { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company to which the user belongs.
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the department of the user.
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the title of the user.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the roles assigned to the user.
        /// </summary>
        public required List<string> Roles { get; set; }
    }
}
