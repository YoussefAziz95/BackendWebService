using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v2;

[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ManagerCdontroller(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-manager")]
    public async Task<IActionResult> AddManager([FromBody] AddManagerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-manager/{id}")]
    public async Task<IActionResult> GetManager([FromRoute] int id)
    {
        var response = mediator.HandleById<ManagerResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-manager")]
    public async Task<IActionResult> UpdateManager([FromBody] UpdateManagerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all")]
    public IActionResult GetAll(ManagerAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-manager")]
    public async Task<IActionResult> DeleteManager([FromBody] DeleteManagerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
}
