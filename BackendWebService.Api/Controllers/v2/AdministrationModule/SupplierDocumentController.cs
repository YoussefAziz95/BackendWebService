using Api.Base;
using Application.Contracts.Services;
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SupplierDocumentController : AppControllerBase
{
    private readonly ISupplierDocumentService _supplierdocumentService;

    public SupplierDocumentController(ISupplierDocumentService supplierdocumentService)
    {
        _supplierdocumentService = supplierdocumentService;
    }

    [HttpPost]


    public async Task<IActionResult> AddSupplierDocument([FromBody] AddSupplierDocumentRequest request)
    {
        var result = await _supplierdocumentService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetSupplierDocument([FromRoute] int id)
    {
        var result = await _supplierdocumentService.GetAsync(id);
        return NewResult(result);
    }

    [HttpPut]


    public async Task<IActionResult> UpdateSupplierDocument([FromBody] UpdateSupplierDocumentRequest request)
    {
        var result = await _supplierdocumentService.UpdateAsync(request);
        return NewResult(result);
    }

    [HttpPost("GetAll/{id}")]

    public async Task<IActionResult> GetAll([FromRoute] int id, [FromBody] SupplierDocumentAllRequest request)
    {
        var result = await _supplierdocumentService.GetPaginated(request);
        return Ok(result);
    }
}
