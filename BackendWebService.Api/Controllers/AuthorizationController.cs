using Api.Base;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;

[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthorizationController : AppControllerBase
{
    private readonly IMediator _mediator;

    public AuthorizationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login-phone")]
    public async Task<IActionResult> Login([FromBody] LoginPhoneRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("login-email")]
    public async Task<IActionResult> LoginEmail([FromBody] LoginEmailRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok(new { message = "Logged out successfully." });
    }

    [HttpPost("refresh-token")]
    [Authorize]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("reset-password/confirm")]
    public async Task<IActionResult> ConfirmResetPassword([FromBody] ConfirmResetPasswordRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("confirm-phone-number")]
    public async Task<IActionResult> ConfirmPhoneNumber([FromBody] ConfirmPhoneNumberRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("otp/send")]
    public async Task<IActionResult> SendOtp([FromBody] PhoneNumberRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("otp/verify")]
    public async Task<IActionResult> VerifyOtp([FromBody] OtpVerifyRequest request)
    {
        var response = await _mediator.HandleAsync(request);
        return NewResult(response);
    }

    //[HttpGet("user-pages/{id}")]
    //public async Task<IActionResult> GetUserPages(int id)
    //{
    //    var response = await _mediator.SendAsync(new GetUserPagesQuery(id));
    //    return NewResult(response);
    //}
    //[HttpGet("GetUserPages/{id}")]
    //public async Task<IActionResult> GetUserPages(int id)
    //{
    //    var result = await _jwtService.GetUserPages(id);
    //    return Ok(result);
    //}
}
