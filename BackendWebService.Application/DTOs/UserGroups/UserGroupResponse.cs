using Application.DTOs.Users;
using Application.Profiles;
using Domain;
using System.Collections.Generic;

namespace Application.DTOs.UserGroups
{
    /// <summary>
    /// Represents a response model for a user group.
    /// </summary>
    public class UserGroupResponse : ICreateMapper<UserGroup>
    {
        /// <summary>
        /// Gets or sets the list of users in the group.
        /// </summary>
        public List<UserResponse> Users { get; set; }
    }
}
