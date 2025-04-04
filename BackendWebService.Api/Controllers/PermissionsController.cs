using BackendWebService.Api.Base;
using Application.Contracts.Services;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionsController : AppControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    [Authorize(PermissionConstants.PERMISSION_VIEW)]
    public IActionResult GetAll()
    {
        var result = _permissionService.GetAll();
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.PERMISSION_VIEW)]
    public async Task<IActionResult> GetRolePermissions([FromRoute] int id)
    {
        var result = await _permissionService.GetRolePermissions(id);
        return NewResult(result);
    }
    [HttpGet("GetUserPages/{id}")]
    [Authorize(PermissionConstants.PERMISSION_VIEW)]
    public async Task<IActionResult> GetUserPages(int id)
    {
        var result = await _permissionService.GetUserPages(id);
        return NewResult(result);
    }
}
