using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace Application.Contracts.Manager;

public interface IAppSignInManager
{
    Task<User?> FindByPhoneNumber(string phoneNumber);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
    bool IsSignedIn(ClaimsPrincipal principal);
    Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
    Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
    Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
    Task SignOutAsync();
    Task<bool> CanSignInAsync(User user);
    Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure);
    AuthenticationProperties ConfigureExternalAuthenticationProperties(string? provider, [StringSyntax("Uri")] string? redirectUrl, string? userId = null);
    Task<ClaimsPrincipal> CreateUserPrincipalAsync(User user);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    Task ForgetTwoFactorClientAsync();
    Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null);
    Task<User?> GetTwoFactorAuthenticationUserAsync();
    Task<bool> IsTwoFactorClientRememberedAsync(User user);
    Task<bool> IsTwoFactorEnabledAsync(User user);
    Task RefreshSignInAsync(User user);
    Task RememberTwoFactorClientAsync(User user);
    Task SignInAsync(User user, bool isPersistent, string? authenticationMethod = null);
    Task SignInAsync(User user, AuthenticationProperties authenticationProperties, string? authenticationMethod = null);
    Task SignInWithClaimsAsync(User user, bool isPersistent, IEnumerable<Claim> additionalClaims);
    Task SignInWithClaimsAsync(User user, AuthenticationProperties? authenticationProperties, IEnumerable<Claim> additionalClaims);
    Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
    Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
    Task<bool> ValidateSecurityStampAsync(User? user, string? securityStamp);
    Task<User?> ValidateSecurityStampAsync(ClaimsPrincipal? principal);
    Task<User?> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal? principal);
}
