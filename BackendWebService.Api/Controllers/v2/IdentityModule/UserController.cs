using Api.Base;
using Application.Contracts.AppManager;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[Authorize]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController(IMediator mediator, IAppUserManager appUserManager) : AppControllerBase
{

    [HttpGet("find-by-id/{id}")]
    public async Task<IActionResult> FindById(int id)
    {
        var user = await appUserManager.FindByIdAsync(id.ToString());
        if (user == null)
            return NotFound();

        return Ok(user);
    }


    [HttpPost("create-with-password")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateWithPassword([FromBody] SignUpRequest request)
    {

        var result = await appUserManager.CreateAsync(request);
        if (result.Succeeded)
            return Ok(result);

        return BadRequest(result.Errors);
    }

    [HttpPost("add-to-role")]
    public async Task<IActionResult> AddToRole([FromBody] RoleAssignRequest request)
    {
        var user = await appUserManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
            return NotFound();

        var result = await appUserManager.AddToRoleAsync(user, request.Role);
        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }

    [HttpGet("get-user-roles/{id}")]
    public async Task<IActionResult> GetUserRoles(int id)
    {
        var user = await appUserManager.FindByIdAsync(id.ToString());
        if (user == null)
            return NotFound();

        var roles = await appUserManager.GetRolesAsync(user);
        return Ok(roles);
    }
    //-------------------------------
    #region User APIs
    //-------------------------------
    [HttpPost("add-user")]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-user/{id}")]
    public IActionResult GetUser([FromRoute] int id)
    {
        var response = mediator.HandleById<UserResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-user")]
    public IActionResult GetAll(UserAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-user")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
    //-------------------------------
    #region UserLogin APIs
    //-------------------------------
    [HttpPost("add-user-login")]
    public async Task<IActionResult> AddUserLogin([FromBody] AddUserLoginRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-user-login/{id}")]
    public IActionResult GetUserLogin([FromRoute] int id)
    {
        var response = mediator.HandleById<UserLoginResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-user-login")]
    public async Task<IActionResult> UpdateUserLogin([FromBody] UpdateUserLoginRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-user-login")]
    public IActionResult GetAll(UserLoginAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-user-login")]
    public async Task<IActionResult> DeleteUserLogin([FromBody] DeleteUserLoginRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
    //-------------------------------
    #region UserRefreshToken APIs
    //-------------------------------
    [HttpPost("add-user-refresh-token")]
    public async Task<IActionResult> AddUserRefreshToken([FromBody] AddUserRefreshTokenRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-user-refresh-token/{id}")]
    public IActionResult GetUserRefreshToken([FromRoute] int id)
    {
        var response = mediator.HandleById<UserRefreshTokenResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-user-refresh-token")]
    public async Task<IActionResult> UpdateUserRefreshToken([FromBody] UpdateUserRefreshTokenRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-user-refresh-token")]
    public IActionResult GetAll(UserRefreshTokenAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-user-refresh-token")]
    public async Task<IActionResult> DeleteUserRefreshToken([FromBody] DeleteUserRefreshTokenRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
    //-------------------------------
    #region UserRole APIs
    //-------------------------------
    [HttpPost("add-user-role")]
    public async Task<IActionResult> AddUserRole([FromBody] AddUserRoleRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-user-role/{id}")]
    public IActionResult GetUserRole([FromRoute] int id)
    {
        var response = mediator.HandleById<UserRoleResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-user-role")]
    public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-user-role")]
    public IActionResult GetAll(UserRoleAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-user-role")]
    public async Task<IActionResult> DeleteUserRole([FromBody] DeleteUserRoleRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
    //-------------------------------
    #region UserToken APIs
    //-------------------------------
    [HttpPost("add-user-token")]
    public async Task<IActionResult> AddUserToken([FromBody] AddUserTokenRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-user-token/{id}")]
    public IActionResult GetUserToken([FromRoute] int id)
    {
        var response = mediator.HandleById<UserTokenResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-user-token")]
    public async Task<IActionResult> UpdateUserToken([FromBody] UpdateUserTokenRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-user-token")]
    public IActionResult GetAll(UserTokenAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-user-token")]
    public async Task<IActionResult> DeleteUserToken([FromBody] DeleteUserTokenRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}




