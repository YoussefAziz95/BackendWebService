using Application.Profiles;
using Domain;

namespace Application.DTOs.UserGroups
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
