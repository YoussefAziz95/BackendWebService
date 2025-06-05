using Api.Base;
using Application.Contracts.Services;
using Application.Features;
using Application.Features.Common;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierDocumentController : AppControllerBase
{
    private readonly ISupplierDocumentService _supplierdocumentService;

    public SupplierDocumentController(ISupplierDocumentService supplierdocumentService)
    {
        _supplierdocumentService = supplierdocumentService;
    }

    [HttpPost]
    [Authorize(PermissionConstants.SUPPLIERDOCUMENT)]

    public async Task<IActionResult> AddSupplierDocument([FromBody] AddSupplierDocumentRequest request)
    {
        var result = await _supplierdocumentService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    [Authorize(PermissionConstants.SUPPLIERDOCUMENT)]
    public async Task<IActionResult> GetSupplierDocument([FromRoute] int id)
    {
        var result = await _supplierdocumentService.GetAsync(id);
        return NewResult(result);
    }

    [HttpPut]
    [Authorize(PermissionConstants.SUPPLIERDOCUMENT)]

    public async Task<IActionResult> UpdateSupplierDocument([FromBody] UpdateSupplierDocumentRequest request)
    {
        var result = await _supplierdocumentService.UpdateAsync(request);
        return NewResult(result);
    }

    [HttpPost("GetAll/{id}")]
    [Authorize(PermissionConstants.SUPPLIERDOCUMENT)]
    public async Task<IActionResult> GetAll([FromRoute] int id, [FromBody] GetPaginatedRequest request)
    {
        var result = await _supplierdocumentService.GetPaginated(id);
        return Ok(result);
    }
}
