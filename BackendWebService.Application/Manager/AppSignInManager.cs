using Application.Contracts.Manager;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Manager;
public class AppSignInManager : SignInManager<User>, IAppSignInManager
{
    public readonly UserManager<User> _userManager;
    public AppSignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<User> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {

    }
    public Task<User?> FindByPhoneNumber(string phoneNumber)
    {
        return _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
    }



}