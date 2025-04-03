using Application.Contracts.Persistence;
using Application.DTOs.Users;
using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendWebService.Application.Profiles
{
    /// <summary>
    /// Provides mapping methods for user-related entities.
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Gets a user response object from the provided application user entity, user manager, and unit of work.
        /// </summary>
        /// <param name="entity">The application user entity.</param>
        /// <param name="userManager">The user manager instance.</param>
        /// <param name="unitOfWork">The unit of work instance.</param>
        /// <returns>A new instance of the <see cref="UserResponse"/> object.</returns>
        public static UserResponse GetResponse(User entity, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            var response = GetResponse(entity, unitOfWork);
            response.Roles = userManager.GetRolesAsync(entity).Result.ToList();
            response.CompanyId = entity.OrganizationId;
            response.MainRole = Enum.GetName(entity.MainRole);

            return response;
        }

        /// <summary>
        /// Gets a user response object from the provided application user entity and unit of work.
        /// </summary>
        /// <param name="entity">The application user entity.</param>
        /// <param name="unitOfWork">The unit of work instance.</param>
        /// <returns>A new instance of the <see cref="UserResponse"/> object.</returns>
        public static UserResponse GetResponse(User entity, IUnitOfWork unitOfWork)
        {
            return new UserResponse
            {
                Id = entity.Id,
                Username = entity.UserName!,
                Email = entity.Email!,
                FirstName = entity.FirstName!,
                LastName = entity.LastName!,
                CreatedDate = entity.CreatedDate,
                UpdateDate = entity.UpdateDate!,
                IsActive = entity.IsActive,
                Title = entity.Title,
                Department = entity.Department,
            };
        }

        /// <summary>
        /// Gets a list of user response objects from the provided list of application user entities, user manager, and unit of work.
        /// </summary>
        /// <param name="entities">The list of application user entities.</param>
        /// <param name="userManager">The user manager instance.</param>
        /// <param name="unitOfWork">The unit of work instance.</param>
        /// <returns>A list of user response objects.</returns>
        public static List<UserResponse> GetResponses(List<User> entities, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            var responses = new List<UserResponse>();

            foreach (var applicationUser in entities)
                responses.Add(GetResponse(applicationUser, userManager, unitOfWork));

            return responses;
        }
    }
}
