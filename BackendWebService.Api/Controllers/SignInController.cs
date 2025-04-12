using Api.Base;
using Application.DTOs.Common;
using BackendWebService.Application.Contracts.Manager;
using BackendWebService.Application.DTOs;
using Contracts.Services;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebService.Controllers;

[Route("api/")]
[ApiController]
[AllowAnonymous]
public class SignInController : AppControllerBase
{
    private readonly IAppUserManager _userManager;
    private readonly IJwtService _jwtService;

    public SignInController(IAppUserManager userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
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
        var user = new User
        {
            UserName = request.Email.Trim().ToLower(),
            Email = request.Email.Trim().ToLower(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            MainRole = request.MainRole,
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


}
