using Application.Validators.Common;

namespace Application.DTOs.User
{
    /// <summary>
    /// Represents a request model for adding a new user.
    /// </summary>
    public class AddUserRequest : BaseValidationModel<AddUserRequest>
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
        /// Gets or sets the department of the user.
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the title of the user.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the company associated with the user.
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user type.
        /// </summary>
        public string? MainRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's password is the default password.
        /// </summary>
        public bool IsDefaultPassword { get; set; } = default;

        /// <summary>
        /// Gets or sets the roles assigned to the user.
        /// </summary>
        public required List<string> Roles { get; set; }
    }
}
