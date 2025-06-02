using Application.Contracts.Services;
using Application.DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Implementations
{
    /// <summary>
    /// Factory class for retrieving authentication service based on the issuer of the access token.
    /// </summary>
    public class AuthenticationFactory
    {
        /// <summary>
        /// Retrieves the appropriate authentication service based on the issuer of the access token.
        /// </summary>
        /// <param name="request">The login authentication request.</param>
        /// <returns>An instance of the authentication service.</returns>
        public IAuthenticationService RetrieveAuthenticateService(LoginAuthenticatorRequest request)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(request.AccessToken);

            if (jwtSecurityToken.Issuer.Contains("google"))
            {
                return new GoogleAuthenticationService(request);
            }
            if (jwtSecurityToken.Issuer.Contains("microsoft"))
            {
                return new MicrosoftAuthenticationService(request);
            }
            return null;
        }
    }
}
