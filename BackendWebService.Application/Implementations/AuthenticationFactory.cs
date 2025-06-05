using Application.Contracts.Services;
using Application.Features;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Implementations;

public class AuthenticationFactory
{
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
