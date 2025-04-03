using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Roles;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Services interface for managing application roles.
    /// </summary>
    public interface IApplicationRoleService
    {
        /// <summary>
        /// Adds a new role asynchronously.
        /// </summary>
        /// <param name="request">The request containing role details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the added role.</returns>
        Task<IResponse<int>> AddRoleAsync(CreateRoleRequest request);

        /// <summary>
        /// Adds a role to a user asynchronously.
        /// </summary>
        /// <param name="request">The request containing role-to-user mapping details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of the operation.</returns>
        Task<IResponse<string>> AddRoleToUserAsync(AddRoleToUserRequest request);

        /// <summary>
        /// Retrieves roles paginated asynchronously.
        /// </summary>
        /// <param name="request">The request containing pagination details.</param>
        /// <returns>A task representing the asynchronous operation, returning the paginated response containing roles.</returns>
        Task<PaginatedResponse<RolesResponse>> GetRolesPaginated(GetPaginatedRequest request);

        /// <summary>
        /// Retrieves a role asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the role to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the retrieved role.</returns>
        Task<IResponse<RoleResponse>> GetRoleAsync(int id);

        /// <summary>
        /// Updates a role asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the role to update.</param>
        /// <param name="request">The request containing updated role details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the updated role.</returns>
        Task<IResponse<int>> UpdateRoleAsync(int id, UpdateRoleRequest request);

        /// <summary>
        /// Deletes a role asynchronously by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the role to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of the operation.</returns>
        Task<IResponse<string>> DeleteRoleAsync(int id);

        /// <summary>
        /// Checks if a role with the specified identifier exists.
        /// </summary>
        /// <param name="id">The identifier of the role to check.</param>
        /// <returns>True if the role exists; otherwise, false.</returns>
        bool CheckIdExists(int id);
    }
}
