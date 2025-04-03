using Application.Contracts.DTOs;
using Application.DTOs.Permission;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Defines operations for managing permissions.
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// Retrieves all permissions.
        /// </summary>
        /// <returns>The response containing a list of all permissions.</returns>
        IResponse<List<string>> GetAll();

        /// <summary>
        /// Retrieves permissions assigned to a role asynchronously.
        /// </summary>
        /// <param name="roleId">The ID of the role to retrieve permissions for.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with permissions assigned to the role.</returns>
        Task<IResponse<PermissionResponse>> GetRolePermissions(int roleId);

        /// <summary>
        /// Adds permissions to a role asynchronously.
        /// </summary>
        /// <param name="request">The request containing information about permissions to add to the role.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with information about the added permissions.</returns>
        Task<IResponse<int>> AddPermissionsToRole(AddPermissionsToRoleRequest request);

        /// <summary>
        /// Retrieves user pages asynchronously by user ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve pages for.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with user pages.</returns>
        Task<IResponse<IEnumerable<UserPagesResponse>>> GetUserPages(int id);
    }
}
