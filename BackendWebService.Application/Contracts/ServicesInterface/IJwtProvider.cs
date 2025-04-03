using Domain;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Interface for JWT token generation services.
    /// </summary>
    public interface IJwtProvider
    {
        /// <summary>
        /// Generates a JWT token for the specified user asynchronously.
        /// </summary>
        /// <param name="user">The user for whom the JWT token is generated.</param>
        /// <returns>A task representing the asynchronous operation. The generated JWT token.</returns>
        Task<string> Generate(User user);
    }
}
