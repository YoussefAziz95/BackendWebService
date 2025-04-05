using Application.Validators.Common;
using Application.Profiles;
using Domain;
using System.Collections.Generic;

namespace Application.DTOs.Users
{
    /// <summary>
    /// Represents a request model for adding a user to a company.
    /// </summary>
    public class AddUserCompanyRequest : BaseValidationModel<AddUserCompanyRequest>, ICreateMapper<User>
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the ID of the company to which the user belongs.
        /// </summary>
        public int? CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the department of the user.
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title of the user.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the user type.
        /// </summary>
        public string? MainRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has the default password.
        /// </summary>
        public bool IsDefaultPassword { get; set; } = default;

        /// <summary>
        /// Gets or sets the roles assigned to the user.
        /// </summary>
        /// 
        public int? OrganizationId { get; set; }

        public required List<string> Roles { get; set; }
    }
}
