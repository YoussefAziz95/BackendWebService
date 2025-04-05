using Application.Profiles;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.DTOs.Users
{
    /// <summary>
    /// Represents a response model for user data.
    /// </summary>
    public class UserResponse : ICreateMapper<User>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public required string LastName { get; set; }

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
        public List<string>? Roles { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was last updated.
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the company associated with the user.
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user type.
        /// </summary>
        public string MainRole { get; set; }

    }
}
