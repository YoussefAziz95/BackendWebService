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
public class ConsumerAccountController(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-consumer-account")]
    public async Task<IActionResult> AddConsumerAccount([FromBody] AddConsumerAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer-account/{id}")]
    public async Task<IActionResult> GetConsumerAccount([FromRoute] int id)
    {
        var response = mediator.HandleById<ConsumerAccountResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-consumer-account")]
    public async Task<IActionResult> UpdateConsumerAccount([FromBody] UpdateConsumerAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all")]
    public IActionResult GetAll(ConsumerAccountAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-consumer-account")]
    public async Task<IActionResult> DeleteConsumerAccount([FromBody] DeleteConsumerAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
}
