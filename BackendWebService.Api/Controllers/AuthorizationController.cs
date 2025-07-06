using Api.Base;
using Application.Contracts.AppManager;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Contracts.Services;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("api/")]
[ApiController]
[AllowAnonymous]
public class AuthorizationController : AppControllerBase
{
    private readonly IAppUserManager _userManager;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOtpService _otpService;

    public AuthorizationController(IAppUserManager userManager, IJwtService jwtService, IUnitOfWork unitOfWork, IOtpService otpService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
        _otpService = otpService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginPhoneRequest request)
    {
        var user = await _userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());

        if (user == null)
            return Unauthorized("Invalid phone number or password");

        //if (!user.PhoneNumberConfirmed)
        //    return Forbid("Phone Number not confirmed");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);


        if (!result)
            return Unauthorized("Invalid phone number or password");


        var roles = await _userManager.GetRolesAsync(user);

        var accessToken = await _jwtService.GenerateAsync(user);
        var response = new Response<LoginResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Login successful",
            Succeeded = true,
            Data = new LoginResponse(
               Id: user.Id,
               FullName: $"{user.FirstName} {user.LastName}",
               PhoneNumber: user.PhoneNumber!,
               Email: user.Email,
               Token: accessToken.access_token,
               TokenExpiry: DateTime.UtcNow.AddMinutes(30),
               MainRole: user.MainRole.ToString(), // Convert RoleEnum to string  
               Department: user.Department,
               Title: user.Title,
               IsActive: user.IsActive ?? true
           )
        };


        return NewResult(response);
    }
    [HttpPost("login-email")]
    public async Task<IActionResult> LoginEmail([FromBody] LoginEmailRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email.Trim());

        if (user == null)
            return Unauthorized("Invalid Email or Pssword");

        //if (!user.EmailConfirmed)
        //    return Forbid("Email not confirmed");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);


        if (!result)
            return Unauthorized("Invalid Email or Pssword");


        var roles = await _userManager.GetRolesAsync(user);

        var accessToken = await _jwtService.GenerateAsync(user);
        var response = new Response<LoginResponse>()
        {
            StatusCode = ApiResultStatusCode.Success,
            Message = "Login successful",
            Succeeded = true,
            Data = new LoginResponse(
                Id: user.Id,
                FullName: $"{user.FirstName} {user.LastName}",
                PhoneNumber: user.PhoneNumber!,
                Email: user.Email,
                Token: accessToken.access_token,
                TokenExpiry: DateTime.UtcNow.AddMinutes(30),
                MainRole: user.MainRole.ToString(), // Convert RoleEnum to string  
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
            Succeeded = true,
            Data = new LoginResponse(
                Id: user.Id,
                FullName: $"{user.FirstName} {user.LastName}",
                PhoneNumber: user.PhoneNumber!,
                Email: user.Email,
                Token: accessToken.access_token,
                TokenExpiry: DateTime.UtcNow.AddMinutes(30),
                MainRole: user.MainRole.ToString(), // Convert RoleEnum to string  
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
        var result = await _jwtService.RefreshTokenAsync(request.Token);
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
            Succeeded = true,
            Data = new LoginResponse(
                Id: user.Id,
                FullName: $"{user.FirstName} {user.LastName}",
                PhoneNumber: user.PhoneNumber!,
                Email: user.Email,
                Token: result.access_token,
                TokenExpiry: DateTime.UtcNow.AddMinutes(30),
                MainRole: user.MainRole.ToString(), // Convert RoleEnum to string  
                Department: user.Department,
                Title: user.Title,
                IsActive: user.IsActive ?? true
            )
        });
    }

    [HttpPost("resetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var user = await _userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest("User not found.");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        // Send token via email or SMS here
        return Ok(new { message = "Password reset instructions sent. " + token });
    }
    [HttpPost("resetPasswordAuth")]
    public async Task<IActionResult> ResetPasswordAuth([FromBody] ResetPasswordAuthRequest request)
    {
        var user = await _userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest("User not found.");

        var result = await _userManager.ChangePasswordAsync(user, request.oldPassword, request.newPassword);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        return Ok(new { message = "Password changed successfully. " });
    }
    [HttpPost("reset-password/confirm")]
    public async Task<IActionResult> ConfirmResetPassword([FromBody] ConfirmResetPasswordRequest request)
    {
        var user = await _userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest("Invalid request.");

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        return result.Succeeded ? Ok("Password reset successfully.") : BadRequest(result.Errors);
    }


    [HttpPost("confirm-phone-number")]
    public async Task<IActionResult> ConfirmPhoneNumber([FromBody] ConfirmPhoneNumberRequest request)
    {
        var user = await _userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest("Invalid request.");

        var result = await _otpService.VerifyAsync(user, request.Code);
        if (!result)
            return BadRequest("Invalid token");
        var response = await _userManager.ConfirmPhoneNumberAsync(user);
        return response.Succeeded ? Ok(response) : BadRequest(response.Errors);
    }
    [HttpPost("otp/send")]
    public async Task<IActionResult> SendOtp([FromBody] PhoneNumberRequest request)
    {
        var user = await _userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest("User not found.");

        // Generate OTP and store it with expiration time
        var otp = _otpService.SendOTP(user);

        // Simulate sending OTP (SMS/etc.)
        Console.WriteLine($"OTP for {user.PhoneNumber}: {otp.Result}");

        return Ok("OTP sent successfully. : " + otp.Result);
    }

    [HttpPost("otp/verify")]
    public async Task<IActionResult> VerifyOtp([FromBody] OtpVerify request)
    {
        var user = await _userManager.FindByPhoneNumberAsync(request.PhoneNumber.Trim());
        if (user == null) return BadRequest("User not found.");


        if (!await _otpService.VerifyAsync(user, request.Code))
        {
            return BadRequest("Invalid OTP.");
        }

        // Remove OTP after successful verification
        await _userManager.RemoveAuthenticationTokenAsync(user, "RFA", "OTP");
        await _userManager.RemoveAuthenticationTokenAsync(user, "RFA", "OTP_TIME");

        // Issue short-lived access token (e.g., 10 minutes)
        var accessToken = await _jwtService.GenerateAsync(user);

        return Ok(new
        {
            Token = accessToken.access_token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(10)
        });
    }
    [HttpGet("GetUserPages/{id}")]
    public async Task<IActionResult> GetUserPages(int id)
    {
        var result = await _userManager.GetUserPages(id);
        return Ok(result);
    }

}
