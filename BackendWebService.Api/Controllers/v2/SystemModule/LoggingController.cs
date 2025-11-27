using Api.Base;
using Application.Contracts.Features;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LoggingController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Logging APIs
    //-------------------------------
    [HttpPost("add-logging")]
    public async Task<IActionResult> AddLogging([FromBody] AddLoggingRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-logging/{id}")]
    public async Task<IActionResult> GetLogging([FromRoute] int id)
    {
        var response = mediator.HandleById<LoggingResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-logging")]
    public async Task<IActionResult> UpdateLogging([FromBody] UpdateLoggingRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-logging")]
    public IActionResult GetAll(LoggingAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-logging")]
    public async Task<IActionResult> DeleteLogging([FromBody] DeleteLoggingRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
