using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Users;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Defines the contract for the application user service, responsible for managing user-related operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Adds a new user asynchronously.
        /// </summary>
        /// <param name="request">The request containing information about the user to be added.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with the ID of the created user.</returns>
        Task<IResponse<int>> AddAsync(AddUserRequest request);


        /// <summary>
        /// Retrieves information about a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The response containing information about the user.</returns>
        IResponse<UserResponse> Get(int id);

        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="request">The request containing updated information about the user.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with the ID of the updated user.</returns>
        Task<IResponse<int>> UpdateAsync(int id, UpdateUserRequest request);

        /// <summary>
        /// Deletes a user asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with a message indicating the outcome of the operation.</returns>
        Task<IResponse<string>> DeleteAsync(int id);

        /// <summary>
        /// Changes the password for a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user whose password will be changed.</param>
        /// <param name="request">The request containing the new password.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with a boolean indicating whether the password change was successful.</returns>
        Task<IResponse<bool>> ChangePassword(int userId, ChangePasswordRequest request);

        /// <summary>
        /// Retrieves a paginated list of users.
        /// </summary>
        /// <param name="request">The request containing pagination parameters.</param>
        /// <returns>The paginated response containing information about users.</returns>
        PaginatedResponse<UserResponse> GetUsersPaginated(GetPaginatedRequest request);

        /// <summary>
        /// Checks if a user ID exists.
        /// </summary>
        /// <param name="id">The ID of the user to check.</param>
        /// <returns>True if the user ID exists; otherwise, false.</returns>
        bool CheckIdExists(int id);

        /// <summary>
        /// Activates or deactivates OTP (One-Time Password) for a user asynchronously.
        /// </summary>
        /// <param name="request">The request containing information about OTP activation/deactivation.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with information about OTP activation/deactivation.</returns>
        Task<IResponse<bool>> ActivateDeactivateOtp(ActivateDeactivateOtpRequest request);

        /// <summary>
        /// Retrieves information about a user asynchronously by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the response with information about the user.</returns>
        Task<IResponse<UserResponse>> GetAsync(int id);
    }
}
