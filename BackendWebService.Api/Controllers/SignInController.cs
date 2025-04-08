using Application.DTOs.SignIn;
using BackendWebService.Application.Contracts.Manager;
using Contracts.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebService.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class SignInController : ControllerBase
{
    private readonly IAppUserManager _userManager;
    private readonly IJwtService _jwtService;

    public SignInController( IAppUserManager userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email.Trim().ToLower());

        if (user == null )
            return Unauthorized("Invalid email or password");

        if (!user.EmailConfirmed)
            return Forbid("Email not confirmed");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);


        if (!result)
            return Unauthorized("Two-factor authentication required");


        var roles = await _userManager.GetRolesAsync(user);
       
        var accessToken = await _jwtService.GenerateAsync(user);
        var response = new LoginResponse(
            Id: user.Id,
            FullName: $"{user.FirstName} {user.LastName}",
            Email: user.Email!,
            Token: accessToken.access_token,
            TokenExpiry: DateTime.UtcNow.AddMinutes(30),
            MainRole: user.MainRole,
            Department: user.Department,
            Title: user.Title,
            IsActive: user.IsActive??true
        // Token = await GenerateJwtToken(user) // optional
        );

        return Ok(response);
    }



}
