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
public class ZoneController(IMediator mediator) : AppControllerBase
{
    //-------------------------------
    #region Zone APIs
    //-------------------------------
    [HttpPost("add-zone")]
    public async Task<IActionResult> AddZone([FromBody] AddZoneRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-zone/{id}")]
    public async Task<IActionResult> GetZone([FromRoute] int id)
    {
        var response = mediator.HandleById<ZoneResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-zone")]
    public async Task<IActionResult> UpdateZone([FromBody] UpdateZoneRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-zone")]
    public IActionResult GetAll(ZoneAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-zone")]
    public async Task<IActionResult> DeleteZone([FromBody] DeleteZoneRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
