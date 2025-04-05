using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Roles;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : AppControllerBase
{
    private readonly IApplicationRoleService _roleService;

    public RolesController(IApplicationRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Authorize(PermissionConstants.ROLE_VIEW)]
    public async Task<IActionResult> GetAll([FromQuery] GetPaginatedRequest request)
    {
        var result = await _roleService.GetRolesPaginated(request);
        return Ok(result);
    }

    [HttpPost("addRoleToUser")]
    [Authorize(PermissionConstants.ROLE_CREATE)]
    [ModelValidator]
    public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleToUserRequest request)
    {
        var result = await _roleService.AddRoleToUserAsync(request);
        return NewResult(result);
    }

    [HttpPost("addRole")]
    [Authorize(PermissionConstants.ROLE_CREATE)]
    [ModelValidator]
    public async Task<IActionResult> AddRole([FromBody] CreateRoleRequest request)
    {
        var result = await _roleService.AddRoleAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.ROLE_GET)]
    public async Task<IActionResult> GetRole([FromRoute] int id)
    {
        var result = await _roleService.GetRoleAsync(id);
        return NewResult(result);
    }

    [HttpDelete("{id}")]
    [Authorize(PermissionConstants.ROLE_DELETE)]
    public async Task<IActionResult> DeleteRole([FromRoute] int id)
    {
        var result = await _roleService.DeleteRoleAsync(id);
        return NewResult(result);
    }

    [HttpPut("{id}")]
    [Authorize(PermissionConstants.ROLE_EDIT)]
    [ModelValidator]
    public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleRequest request)
    {
        var result = await _roleService.UpdateRoleAsync(id, request);
        return NewResult(result);
    }
}
