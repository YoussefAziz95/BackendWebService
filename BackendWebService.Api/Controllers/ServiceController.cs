using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Services;
using Application.Validators.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Base;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : AppControllerBase
{
    private readonly IServiceImplementation _materialService;

    public ServiceController(IServiceImplementation materialService)
    {
        _materialService = materialService;
    }

    [HttpPost]
    [Authorize(PermissionConstants.MATERIAL_CREATE)]
    [ModelValidator]
    public async Task<IActionResult> AddService([FromBody] AddServiceRequest request)
    {
        var result = await _materialService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.MATERIAL_GET)]
    public async Task<IActionResult> GetService([FromRoute] int id)
    {
        var result = await _materialService.GetAsync(id);
        return NewResult(result);
    }

    [HttpDelete("{id}")]
    [Authorize(PermissionConstants.MATERIAL_DELETE)]
    public async Task<IActionResult> DeleteService([FromRoute] int id)
    {
        var result = await _materialService.DeleteAsync(id);
        return NewResult(result);
    }

    [HttpPut]
    [Authorize(PermissionConstants.MATERIAL_EDIT)]
    [ModelValidator]
    public async Task<IActionResult> UpdateService( [FromBody] UpdateServiceRequest request)
    {
        var result = await _materialService.UpdateAsync( request);
        return NewResult(result);
    }

    [HttpPost("GetAll")]
    [Authorize(PermissionConstants.MATERIAL_VIEW)]
    public async Task<IActionResult> GetAll([FromBody] GetPaginatedRequest request)
    {
        var result = await _materialService.GetPaginated(request);
        return Ok(result);
    }
}
