namespace Application.Contracts.Services
{
    /// <summary>
    /// Interface for authentication-related services.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Checks if the user is authenticated.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. Returns true if the user is authenticated; otherwise, false.</returns>
        Task<bool> IsAuthenticated();

        /// <summary>
        /// Retrieves the email associated with the authenticated user.
        /// </summary>
        /// <returns>The email associated with the authenticated user.</returns>
        string getEmail();
    }
}
