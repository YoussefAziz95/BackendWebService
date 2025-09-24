using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PropertyController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Property APIs
    //-------------------------------
    [HttpPost("add-property")]
    public async Task<IActionResult> AddProperty([FromBody] AddPropertyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-property/{id}")]
    public async Task<IActionResult> GetProperty([FromRoute] int id)
    {
        var response = mediator.HandleById<PropertyResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-property")]
    public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-property")]
    public IActionResult GetAll(PropertyAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-property")]
    public async Task<IActionResult> DeleteProperty([FromBody] DeletePropertyRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
