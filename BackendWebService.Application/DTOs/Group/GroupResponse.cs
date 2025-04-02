using Application.DTOs.Common;
using Application.DTOs.User;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Group
{
    /// <summary>
    /// Represents a response model for a group.
    /// </summary>
    public class GroupResponse
    {
        /// <summary>
        /// Gets or sets the ID of the group.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of users belonging to the group.
        /// </summary>
        public List<UserResponse> Users { get; set; }
    }
}
