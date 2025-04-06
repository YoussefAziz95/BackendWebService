using Application.DTOs.Users;
using BackendWebService.Application.Contracts.Manager;
using BackendWebService.Application.DTOs.Users;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebService.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IAppUserManager _appUserManager;

    public UsersController(IAppUserManager appUserManager)
    {
        _appUserManager = appUserManager;
    }

    [HttpGet("find-by-id/{id}")]
    public async Task<IActionResult> FindById(int id)
    {
        var user = await _appUserManager.FindByIdAsync(id.ToString());
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost("create")]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        var result = await _appUserManager.CreateAsync(user);
        if (result.Succeeded)
            return Ok(user);

        return BadRequest(result.Errors);
    }

    [HttpPost("create-with-password")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateWithPassword([FromBody] CreateUserWithPasswordRequest request)
    {

        var result = await _appUserManager.CreateAsync(request);
        if (result.Succeeded)
            return Ok(result);

        return BadRequest(result.Errors);
    }

    [HttpPost("add-to-role")]
    public async Task<IActionResult> AddToRole([FromBody] RoleAssignRequest request)
    {
        var user = await _appUserManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
            return NotFound();

        var result = await _appUserManager.AddToRoleAsync(user, request.Role);
        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }

    [HttpGet("get-user-roles/{id}")]
    public async Task<IActionResult> GetUserRoles(int id)
    {
        var user = await _appUserManager.FindByIdAsync(id.ToString());
        if (user == null)
            return NotFound();

        var roles = await _appUserManager.GetRolesAsync(user);
        return Ok(roles);
    }
}




