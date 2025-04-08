using Application.DTOs.Users;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackendWebService.Application.Contracts.Manager
{
    public interface IAppSignInManager
    {
        public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        public Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        public bool IsSignedIn(ClaimsPrincipal principal);
        public Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
        public Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
        public Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
        public Task SignOutAsync();
        public Task<bool> CanSignInAsync(User user);
        public Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure);
        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string? provider, [StringSyntax("Uri")] string? redirectUrl, string? userId = null);
        public Task<ClaimsPrincipal> CreateUserPrincipalAsync(User user);
        public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        public Task ForgetTwoFactorClientAsync();
        public Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null);
        public Task<User?> GetTwoFactorAuthenticationUserAsync();
        public Task<bool> IsTwoFactorClientRememberedAsync(User user);
        public Task<bool> IsTwoFactorEnabledAsync(User user);
        public Task RefreshSignInAsync(User user);
        public Task RememberTwoFactorClientAsync(User user);
        public Task SignInAsync(User user, bool isPersistent, string? authenticationMethod = null);
        public Task SignInAsync(User user, AuthenticationProperties authenticationProperties, string? authenticationMethod = null);
        public Task SignInWithClaimsAsync(User user, bool isPersistent, IEnumerable<Claim> additionalClaims);
        public Task SignInWithClaimsAsync(User user, AuthenticationProperties? authenticationProperties, IEnumerable<Claim> additionalClaims);
        public Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
        public Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
        public Task<bool> ValidateSecurityStampAsync(User? user, string? securityStamp);
        public Task<User?> ValidateSecurityStampAsync(ClaimsPrincipal? principal);
        public Task<User?> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal? principal);
    }
}
