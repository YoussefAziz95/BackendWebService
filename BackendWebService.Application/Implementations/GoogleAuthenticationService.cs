using Application.Contracts.Services;
using Application.DTOs.Auth.Request;
using Application.Model.Authentication;
using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Application.Implementations
{
    /// <summary>
    /// Services for Google authentication.
    /// </summary>
    public class GoogleAuthenticationService : IAuthenticationService
    {
        private LoginAuthenticatorRequest _request { get; set; }
        private Payload _payload { get; set; }

        /// <summary>
        /// Constructor for GoogleAuthenticationService.
        /// </summary>
        /// <param name="request">The authentication request containing the access token.</param>
        public GoogleAuthenticationService(LoginAuthenticatorRequest request)
        {
            _request = request;
        }

        /// <summary>
        /// Retrieves the email associated with the authenticated Google user.
        /// </summary>
        /// <returns>The email associated with the authenticated Google user.</returns>
        public string getEmail()
        {
            return _payload.Email;
        }

        /// <summary>
        /// Validates the access token and determines whether the user is authenticated.
        /// </summary>
        /// <returns>A boolean indicating whether the user is authenticated.</returns>
        public async Task<bool> IsAuthenticated()
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { GoogleAuthentication.clientId }
            };
            try
            {
                _payload = await GoogleJsonWebSignature.ValidateAsync(_request.AccessToken, settings);
            }
            catch (InvalidJwtException ex)
            {
                return false;
            }
            return true;
        }
    }
}
