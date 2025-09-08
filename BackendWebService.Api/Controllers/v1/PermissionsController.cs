using Api.Base;
using Application.Contracts.Services;
using Application.Features;
using Domain.Constants;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;


[ApiController]
[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PermissionsController : AppControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    [Authorize(PermissionConstants.PERMISSION)]
    public IActionResult GetAll()
    {
        var result = _permissionService.GetAll();
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.PERMISSION)]
    public async Task<IActionResult> GetRolePermissions([FromRoute] int id)
    {
        var result = await _permissionService.GetRolePermissions(id);
        return NewResult(result);
    }
    [HttpGet("GetUserPages/{id}")]
    //[Authorize(PermissionConstants.PERMISSION)]
    public async Task<IActionResult> GetUserPages(int id)
    {
        var result = await _permissionService.GetUserPages(id);
        var response = new Response<IEnumerable<UserPagesResponse>>()
        {
            Data = result,
            StatusCode = ApiResultStatusCode.Success,
            Succeeded = true,
            Message = "User pages retrieved successfully"
        };
        return NewResult(response);
    }
}
