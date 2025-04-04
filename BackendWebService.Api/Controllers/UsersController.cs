using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Users;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendWebService.Api.Base;

namespace BackendWebService.Api.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class UsersController : AppControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize(PermissionConstants.USER_CREATE)]
    [HttpPost]
    [ModelValidator]
    public async Task<IActionResult> Add([FromBody] AddUserRequest request)
    {
        var result = await _userService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet]
    [Authorize(PermissionConstants.USER_GET)]
    [Route("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var result = _userService.Get(id);
        return NewResult(result);
    }

    [HttpPut("{id}")]
    [Authorize(PermissionConstants.USER_EDIT)]
    [ModelValidator]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest request)
    {
        var result = await _userService.UpdateAsync(id, request);
        return NewResult(result);
    }

    [HttpDelete]
    [Authorize(PermissionConstants.USER_DELETE)]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _userService.DeleteAsync(id);
        return NewResult(result);
    }

    [HttpGet]
    [Authorize(Policy = PermissionConstants.USER_VIEW)]
    public IActionResult GetAll([FromQuery] GetPaginatedRequest request)
    {
        var result = _userService.GetUsersPaginated(request);
        return Ok(result);
    }

    [HttpPost]
    [ModelValidator]
    [Route("ChangePassword/{id}")]
    public async Task<IActionResult> ChangePassword([FromRoute] int id, [FromBody] ChangePasswordRequest request)
    {
        var result = await _userService.ChangePassword(id, request);
        return NewResult(result);
    }

    [HttpPost("ActivateDeactivateOtp")]
    [Authorize]
    public async Task<IActionResult> ActivateDeactivateOtp(ActivateDeactivateOtpRequest request)
    {
        var result = await _userService.ActivateDeactivateOtp(request);
        if (request.HasOtp && result.Succeeded)
            HttpContext.Session.SetString(AppConstants.UserOtpType, "false");
        else HttpContext.Session.Remove(AppConstants.UserOtpType);
        return NewResult(result);
    }
}
