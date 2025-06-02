using Application.Contracts.Services;
using Application.DTOs;
using Application.Model.Authentication;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Implementations
{
    /// <summary>
    /// Services implementation for Microsoft authentication.
    /// </summary>
    public class MicrosoftAuthenticationService : IAuthenticationService
    {
        private readonly LoginAuthenticatorRequest _request;
        private JwtSecurityToken _jwtToken;

        public MicrosoftAuthenticationService(LoginAuthenticatorRequest request)
        {
            _request = request;
        }

        /// <summary>
        /// Retrieves the email from the JWT token payload.
        /// </summary>
        /// <returns>The email address associated with the authenticated user.</returns>
        public string getEmail()
        {
            return _jwtToken?.Payload?.First(x => x.Key == "preferred_username").Value.ToString();
        }

        /// <summary>
        /// Checks if the user is authenticated based on the provided access token.
        /// </summary>
        /// <returns>True if the user is authenticated; otherwise, false.</returns>
        public async Task<bool> IsAuthenticated()
        {
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
            $"{MicrosoftAuthentication.instance}{MicrosoftAuthentication.tenantId}/.well-known/openid-configuration",
            new OpenIdConnectConfigurationRetriever(),
            new HttpDocumentRetriever());

            var discoveryDocument = await configurationManager.GetConfigurationAsync();

            var validationParameters = new TokenValidationParameters
            {
                ValidAudiences = new List<string> { MicrosoftAuthentication.clientId },
                ValidIssuer = $"{MicrosoftAuthentication.instance}{MicrosoftAuthentication.tenantId}/v2.0",
                IssuerSigningKey = discoveryDocument.SigningKeys.FirstOrDefault(),
            };

            try
            {
                var handler = new JwtSecurityTokenHandler();
                _jwtToken = handler.ReadToken(_request.AccessToken) as JwtSecurityToken;

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(_request.AccessToken, validationParameters, out _);

                // Access claims from principal.Claims if needed

                return true;
            }
            catch (SecurityTokenException)
            {
                // Token validation failed
                return false;
            }
        }
    }
}
