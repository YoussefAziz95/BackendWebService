using BackendWebService.Application.Contracts.Manager;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Application.Manager;
public class AppSignInManager : SignInManager<User>, IAppSignInManager
{
    public AppSignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<User> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
    }

  
    //public async Task<SignInResult> Auths(User user, string password, bool lockoutOnFailure)
    //{
    //    PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
    //    if(user.PasswordHash == null)
    //        return SignInResult.Failed;

    //    var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
    //    if (result == PasswordVerificationResult.Success)
    //    {
    //        return SignInResult.Success;
    //    }
    //    else if (result == PasswordVerificationResult.SuccessRehashNeeded)
    //    {
    //        user.PasswordHash = passwordHasher.HashPassword(user, password);
    //        await UserManager.UpdateAsync(user);
    //        return SignInResult.Success;
    //    }
    //    else
    //    {
    //        return SignInResult.Failed;
    //    }
    //}

}