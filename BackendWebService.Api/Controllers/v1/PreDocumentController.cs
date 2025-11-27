using Api.Base;
using Application.Contracts.Services;
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PreDocumentController : AppControllerBase
{
    private readonly IPreDocumentService _preDocumentService;

    public PreDocumentController(IPreDocumentService preDocumentService)
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

    public IActionResult GetAll([FromBody] PreDocumentAllRequest request)
    {
        var result = _preDocumentService.GetPaginated(request);
        return Ok(result);
    }

    [HttpGet]

    public IActionResult GetAll()
    {
        var result = _preDocumentService.GetAllAsync();
        return Ok(result);
    }
}
