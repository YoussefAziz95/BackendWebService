using Application.DTOs.Common;
using Application.DTOs.User;
using System.Threading.Tasks;
using Application.DTOs.Auth.Request;
using Application.DTOs.Auth.Response;
using Application.Contracts.DTOs;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Service interface for authentication-related operations.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="request">The request containing user registration details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing authentication details.</returns>
        Task<IResponse<AuthResponse>> RegisterAsync(AddUserRequest request);

        /// <summary>
        /// Logs in a user asynchronously.
        /// </summary>
        /// <param name="request">The request containing user login details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing authentication details.</returns>
        Task<IResponse<AuthResponse>> LoginAsync(LoginRequest request);

        /// <summary>
        /// Logs in a user using authenticator app asynchronously.
        /// </summary>
        /// <param name="request">The request containing user login details for authenticator app.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing authentication details.</returns>
        Task<IResponse<AuthResponse>> LoginAuthenticatorAsync(LoginAuthenticatorRequest request);

        /// <summary>
        /// Refreshes a token asynchronously.
        /// </summary>
        /// <param name="token">The refresh token.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the refreshed authentication details.</returns>
        Task<IResponse<AuthResponse>> RefreshTokenAsync(string token);

        /// <summary>
        /// Revokes a token asynchronously.
        /// </summary>
        /// <param name="token">The token to revoke.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of token revocation.</returns>
        Task<IResponse<bool>> RevokeTokenAsync(string token);

        /// <summary>
        /// Confirms an OTP (One-Time Password) asynchronously.
        /// </summary>
        /// <param name="request">The request containing OTP confirmation details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of OTP confirmation.</returns>
        Task<IResponse<bool>> ConfirmOtp(ConfirmOtpRequest request);

        /// <summary>
        /// Sends a confirmation email asynchronously.
        /// </summary>
        /// <param name="request">The request containing email confirmation details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of email confirmation.</returns>
        Task<IResponse<bool>> SendConfirmEmailAsync(SendConfirmEmailRequest request);

        /// <summary>
        /// Confirms an email asynchronously.
        /// </summary>
        /// <param name="request">The request containing email confirmation details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of email confirmation.</returns>
        Task<IResponse<bool>> ConfirmEmailAsync(ConfirmEmailRequest request);

        /// <summary>
        /// Initiates the process for forgetting password asynchronously.
        /// </summary>
        /// <param name="request">The request containing user details for forgetting password.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of password reset initiation.</returns>
        Task<IResponse<string>> ForgetPassword(ForgetPasswordRequest request);

        /// <summary>
        /// Resets password asynchronously.
        /// </summary>
        /// <param name="request">The request containing user details for password reset.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of password reset.</returns>
        Task<IResponse<string>> ResetPassword(ResetPasswordRequest request);

        /// <summary>
        /// Resets password for authenticated user asynchronously.
        /// </summary>
        /// <param name="request">The request containing user details for password reset.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of password reset.</returns>
        Task<IResponse<string>> ResetPasswordAuth(ResetPasswordRequest request);

        /// <summary>
        /// Deletes super password asynchronously.
        /// </summary>
        /// <param name="request">The request containing super password deletion details.</param>
        /// <returns>A task representing the asynchronous operation, returning the response containing the result of super password deletion.</returns>
        Task<IResponse<bool>> DeleteSuperPassword(DeleteSuperPasswordRequest request);
    }
}
