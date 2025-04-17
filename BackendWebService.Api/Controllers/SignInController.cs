using Api.Base;
using Application.Contracts.Manager;
using Application.Contracts.Persistences;
using Application.DTOs;
using Application.DTOs.Common;
using Application.Models.Jwt;
using Contracts.Services;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("api/")]
[ApiController]
[AllowAnonymous]
public class SignInController : AppControllerBase
{
    private readonly IAppUserManager _userManager;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;

    public SignInController(IAppUserManager userManager, IJwtService jwtService, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.PhoneNumber.Trim());

        if (user == null)
            return Unauthorized("Invalid email or password");

        if (!user.EmailConfirmed)
            return Forbid("PhoneNumber not confirmed");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);


        if (!result)
            return Unauthorized("Two-factor authentication required");


        var roles = await _userManager.GetRolesAsync(user);

        var accessToken = await _jwtService.GenerateAsync(user);
        var response = new Response<LoginResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Login successful",
            Data = new LoginResponse(
                Id: user.Id,
                FullName: $"{user.FirstName} {user.LastName}",
                Email: user.Email!,
                Token: accessToken.access_token,
                TokenExpiry: DateTime.UtcNow.AddMinutes(30),
                MainRole: user.MainRole,
                Department: user.Department,
                Title: user.Title,
                IsActive: user.IsActive ?? true
            )

        };


        return NewResult(response);
    }
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] CreateUserWithPasswordRequest request)
    {
        if (!Enum.TryParse<RoleEnum>(request.MainRole, out var mainRole))
        {
            return BadRequest("Invalid role specified");
        }

        var user = new User
        {
            UserName = request.Email.Trim().ToLower(),
            Email = request.Email.Trim().ToLower(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            MainRole = mainRole,
            Department = request.Department,
            Title = request.Title
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        var accessToken = await _jwtService.GenerateAsync(user);
        var response = new Response<LoginResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Sign up successful",
            Data = new LoginResponse(
                Id: user.Id,
                FullName: $"{user.FirstName} {user.LastName}",
                Email: user.Email!,
                Token: accessToken.access_token,
                TokenExpiry: DateTime.UtcNow.AddMinutes(30),
                MainRole: user.MainRole,
                Department: user.Department,
                Title: user.Title,
                IsActive: user.IsActive ?? true
            )
        };
        return NewResult(response);
    }
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // Logic to revoke token or clear session if implemented
        return Ok(new { message = "Logged out successfully." });
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var result = await _jwtService.RefreshTokenAsync(request.Token, request.RefreshToken);
        if (result == null)
            return Unauthorized("Invalid refresh token");

        var userInfo = _unitOfWork.GetUserInfo();
        if (userInfo == null)
            return Unauthorized("User not found");

        var user = await _userManager.FindByIdAsync(userInfo.UserId.ToString());

        return NewResult(new Response<LoginResponse>
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Token refreshed",
              Data = new LoginResponse(
                Id: user.Id,
                FullName: $"{user.FirstName} {user.LastName}",
                Email: user.Email!,
                Token: result.access_token,
                TokenExpiry: DateTime.UtcNow.AddMinutes(30),
                MainRole: user.MainRole,
                Department: user.Department,
                Title: user.Title,
                IsActive: user.IsActive ?? true
            )
        });
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPasswordRequest([FromBody] ResetPasswordRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) return BadRequest("User not found.");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        // Send token via email or SMS here
        return Ok(new { message = "Password reset instructions sent." });
    }

    [HttpPost("reset-password/confirm")]
    public async Task<IActionResult> ConfirmResetPassword([FromBody] ConfirmResetPasswordRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) return BadRequest("Invalid request.");

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        return result.Succeeded ? Ok("Password reset successfully.") : BadRequest(result.Errors);
    }

    [HttpPost("verify-email")]
    public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) return BadRequest("Invalid request.");

        var result = await _userManager.ConfirmEmailAsync(user, request.Token);
        return result.Succeeded ? Ok("Email verified.") : BadRequest(result.Errors);
    }

    //[HttpPost("mfa/enable")]
    //public async Task<IActionResult> EnableMfa([FromBody] MfaRequest request)
    //{
    //    var user = await _userManager.FindByEmailAsync(request.Email);
    //    var result = await _userManager.SetTwoFactorEnabledAsync(user, true);
    //    return result.Succeeded ? Ok("MFA enabled.") : BadRequest(result.Errors);
    //}

    //[HttpPost("mfa/verify")]
    //public async Task<IActionResult> VerifyMfa([FromBody] MfaVerifyRequest request)
    //{
    //    var user = await _userManager.FindByEmailAsync(request.Email);
    //    var result = await _userManager.VerifyTwoFactorTokenAsync(user, "Email", request.Code);
    //    return result ? Ok("MFA verified.") : BadRequest("Invalid code.");
    //}

    //[HttpPost("mfa/disable")]
    //public async Task<IActionResult> DisableMfa([FromBody] MfaRequest request)
    //{
    //    var user = await _userManager.FindByEmailAsync(request.Email);
    //    var result = await _userManager.SetTwoFactorEnabledAsync(user, false);
    //    return result.Succeeded ? Ok("MFA disabled.") : BadRequest(result.Errors);
    //}



}
