using Api.Base;
using Application.Contracts.Services;
using Application.Features;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.v2.AdministrationModule;


[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PreDocumentsController : AppControllerBase
{
    private readonly IPreDocumentService _preDocumentService;

    public PreDocumentsController(IPreDocumentService preDocumentService)
    {
        _preDocumentService = preDocumentService;
    }

    [HttpPost]
    //

    public async Task<IActionResult> AddPreDocument([FromBody] AddPreDocumentRequest request)
    {
        var result = await _preDocumentService.AddAsync(request);
        return NewResult(result);
    }

    [HttpGet("{id}")]
    
    public async Task<IActionResult> GetPreDocument([FromRoute] int id)
    {
        var result = await _preDocumentService.GetAsync(id);
        return NewResult(result);
    }

    [HttpDelete("{id}")]
    
    public async Task<IActionResult> DeletePreDocument([FromRoute] int id)
    {
        var result = await _preDocumentService.DeleteAsync(id);
        return NewResult(result);
    }

    [HttpPut("{id}")]
    //

    public async Task<IActionResult> UpdatePreDocument([FromRoute] int id, [FromBody] UpdatePreDocumentRequest request)
    {
        var result = await _preDocumentService.UpdateAsync(id, request);
        return NewResult(result);
    }

    [HttpPost("GetAll")]
    
    public async Task<IActionResult> GetAll([FromBody] PreDocumentAllRequest request)
    {
        var result = await _preDocumentService.GetPaginated(request);
        return Ok(result);
    }

    [HttpGet]
    
    public async Task<IActionResult> GetAll()
    {
        var result = await _preDocumentService.GetAllAsync();
        return Ok(result);
    }
}
