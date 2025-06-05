using Api.Base;
using Application.Contracts.Services;
using Application.Features;
using Application.Features.Common;
using Domain;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : AppControllerBase
{
    private readonly ISupplierService _supplierService;
    private readonly UserManager<User> _userManager;

    public SupplierController(ISupplierService supplierService, UserManager<User> userManager)
    {
        _supplierService = supplierService;
        _userManager = userManager;
    }

    [HttpPost("add")]
    [Authorize(PermissionConstants.SUPPLIER)]

    public async Task<IActionResult> AddSupplier([FromBody] AddSupplierRequest request)
    {
        var result = await _supplierService.AddRegisteredAsync(request);
        return NewResult(result);
    }
    [HttpPut("Register/{id}")]
    [Authorize(PermissionConstants.SUPPLIER)]

    public async Task<IActionResult> AddSupplier([FromRoute] int id)
    {
        var result = await _supplierService.RegisterAsync(id);
        return NewResult(result);
    }
    [HttpGet("{id}")]
    [Authorize(PermissionConstants.SUPPLIER)]
    public async Task<IActionResult> GetSupplier([FromRoute] int id)
    {
        var result = await _supplierService.GetAsync(id);
        return NewResult(result);
    }

    [HttpPut("{id}")]
    [Authorize(PermissionConstants.SUPPLIER)]

    public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierRequest request)
    {
        var result = await _supplierService.UpdateAsync(request);
        return NewResult(result);
    }

    [HttpPost("GetAll")]
    [Authorize(PermissionConstants.SUPPLIER)]
    public async Task<IActionResult> GetAll([FromBody] GetPaginatedRequest request)
    {
        var result = await _supplierService.GetPaginated(request);
        return Ok(result);
    }

    [HttpPost("GetRegisterSuppliers")]
    [Authorize(PermissionConstants.SUPPLIER)]
    public async Task<IActionResult> GetRegisterSuppliers([FromBody] GetPaginatedRequest request)
    {
        var result = await _supplierService.GetRegisterSuppliers(request);
        return Ok(result);
    }

    [HttpPost("{id}")]
    [Authorize(PermissionConstants.SUPPLIER)]
    public async Task<IActionResult> DeleteSupplier([FromRoute] int id, [FromBody] DeleteSuperPasswordRequest deleteSuperPasswordRequest)
    {
        if (deleteSuperPasswordRequest.SuperPassword == "")
        {
            // If validation fails, return bad request with errors
            return BadRequest("Enter Password");
        }

        // Validation passed, proceed with deletion
        var result = await _supplierService.DeleteAsync(id);
        return NewResult(result);
    }

    [HttpPost("addSupplierToCompany")]
    [Authorize(PermissionConstants.SUPPLIER)]

    public async Task<IActionResult> AddSupplierToCompany([FromBody] AddSupplierToCompany request)
    {
        var result = await _supplierService.AddSupplierTOCompany(request);
        return NewResult(result);
    }
}
