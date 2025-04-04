using Application.Contracts.Services;
using Application.DTOs.Auths;
using Application.DTOs.Suppliers;
using Application.DTOs.Users;
using Application.Validators.Common;
using BackendWebService.Api.Base;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebService.Api.Controllers;

[Route("api/Admin")]
[ApiController]
[AllowAnonymous]
public class AuthController : AppControllerBase
{
    private readonly IAuthService _authService;
    private readonly ISupplierService _supplierService;

    public AuthController(IAuthService authService,
        ISupplierService supplierService)
    {
        _authService = authService;
        _supplierService = supplierService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] AddUserRequest request)
    {
        var result = await _authService.RegisterAsync(request);
        return NewResult(result);
    }

    [HttpPost("registerSupplier")]
    [ModelValidator]
    public async Task<IActionResult> RegisterSupplierAsync([FromBody] AddSupplierRequest request)
    {

        var result = await _supplierService.AddUnregisteredAsync(request);
        return NewResult(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);
        return NewResult(result);
    }

    [HttpPost("loginAuthenticator")]
    public async Task<IActionResult> LoginAuthenticatorAsync([FromBody] LoginAuthenticatorRequest request)
    {
        var result = await _authService.LoginAuthenticatorAsync(request);
        return NewResult(result);
    }

    [HttpPost("confirmOtp")]
    [Authorize]
    public async Task<IActionResult> ConfirmOtp([FromBody] ConfirmOtpRequest request)
    {
        var result = await _authService.ConfirmOtp(request);
        if (result.Succeeded)
            HttpContext.Session.SetString(AppConstants.UserOtpType, "true");
        return NewResult(result);
    }

    [HttpPost("forgetPassword")]
    public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
    {
        var result = await _authService.ForgetPassword(request);
        return NewResult(result);
    }

    [HttpPost("resetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var result = await _authService.ResetPassword(request);
        return NewResult(result);
    }

    [HttpPost("resetPasswordAuth")]
    [Authorize]
    public async Task<IActionResult> ResetPasswordAuth([FromBody] ResetPasswordRequest request)
    {
        var result = await _authService.ResetPasswordAuth(request);
        return NewResult(result);
    }

    [HttpPost("sendConfirmEmail")]
    public async Task<IActionResult> SendConfirmEmail([FromBody] SendConfirmEmailRequest email)
    {
        var result = await _authService.SendConfirmEmailAsync(email);
        return NewResult(result);
    }

    [HttpPost("confirmEmail")]
    public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
    {
        var result = await _authService.ConfirmEmailAsync(request);
        return NewResult(result);
    }

    private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = expires.ToLocalTime(),
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }
}
