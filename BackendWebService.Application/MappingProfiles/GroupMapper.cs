using Application.Contracts.Presistence;
using Application.DTOs.Group;
using Application.DTOs.User;



namespace Application.MappingProfiles
{
    /// <summary>
    /// Static class containing methods to map group-related entities and DTOs.
    /// </summary>
    public static class GroupMapper
    {
        /// <summary>
        /// Maps a group entity to a group response DTO.
        /// </summary>
        /// <param name="entity">The group entity to map.</param>
        /// <param name="unitOfWork">The unit of work for database operations.</param>
        /// <returns>The mapped group response DTO.</returns>
        public static GroupResponse GetResponse(Group entity, IUnitOfWork unitOfWork)
        {
            var response = new GroupResponse()
            {
                Id = entity.Id,
                Users = new List<UserResponse>()
            };

            if (entity.UserGroups != null)
            {
                foreach (var userGroup in entity.UserGroups)
                {
                    response.Users.Add(UserMapper.GetResponse(userGroup.User, unitOfWork));
                }
            }

            return response;
        }
    }
}
