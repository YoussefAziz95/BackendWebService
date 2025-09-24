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
public class ConsumerController(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-consumer")]
    public async Task<IActionResult> AddConsumer([FromBody] AddConsumerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer/{id}")]
    public async Task<IActionResult> GetConsumer([FromRoute] int id)
    {
        var response = mediator.HandleById<ConsumerResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-consumer")]
    public async Task<IActionResult> UpdateConsumer([FromBody] UpdateConsumerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all")]
    public IActionResult GetAll(ConsumerAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-consumer")]
    public async Task<IActionResult> DeleteConsumer([FromBody] DeleteConsumerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
}
