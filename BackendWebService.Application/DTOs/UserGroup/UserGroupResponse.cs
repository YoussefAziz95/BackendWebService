using Application.DTOs.User;

namespace Application.DTOs.UserGroup
{
    /// <summary>
    /// Represents a response model for a user group.
    /// </summary>
    public class UserGroupResponse
    {
        /// <summary>
        /// Gets or sets the list of users in the group.
        /// </summary>
        public List<UserResponse> Users { get; set; }
    }
}
