using Application.DTOs.SignIn;
using BackendWebService.Application.Contracts.Manager;
using BackendWebService.Application.DTOs.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebService.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class SignInController : ControllerBase
{
    private readonly IAppSignInManager _signInManager;
    private readonly IAppUserManager _userManager;

    public SignInController(IAppSignInManager signInManager, IAppUserManager userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user == null)
            return Unauthorized("Invalid username or password");

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
        if (result.Succeeded)
            return Ok("Login successful");
        if (result.IsLockedOut)
            return Forbid("User account is locked");
        if (result.RequiresTwoFactor)
            return Unauthorized("2FA required");

        return Unauthorized("Invalid login attempt");
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok("Signed out successfully");
    }

    [HttpPost("2fa/code")]
    public async Task<IActionResult> TwoFactorCode([FromBody] TwoFactorRequest request)
    {
        var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(request.Code, request.RememberMe, request.RememberClient);
        if (result.Succeeded)
            return Ok("2FA login successful");

        return Unauthorized("Invalid 2FA code");
    }

    [HttpPost("2fa/recovery")]
    public async Task<IActionResult> Recovery([FromBody] RecoveryCodeRequest request)
    {
        var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(request.RecoveryCode);
        if (result.Succeeded)
            return Ok("Recovery login successful");

        return Unauthorized("Invalid recovery code");
    }

    [HttpGet("is-signed-in")]
    public IActionResult IsSignedIn()
    {
        bool signedIn = _signInManager.IsSignedIn(User);
        return Ok(new { signedIn });
    }

    [HttpGet("external-providers")]
    public async Task<IActionResult> GetExternalProviders()
    {
        var schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
        return Ok(schemes.Select(x => x.Name));
    }

    [HttpPost("external-login")]
    public async Task<IActionResult> ExternalLogin([FromBody] ExternalLoginRequest request)
    {
        var result = await _signInManager.ExternalLoginSignInAsync(request.Provider, request.ProviderKey, true);
        if (result.Succeeded)
            return Ok("External login successful");

        return Unauthorized("External login failed");
    }
}
