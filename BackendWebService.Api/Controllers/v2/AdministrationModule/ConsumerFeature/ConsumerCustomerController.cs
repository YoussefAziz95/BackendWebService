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
public class ConsumerCustomerController(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-consumer-customer")]
    public async Task<IActionResult> AddConsumerCustomer([FromBody] AddConsumerCustomerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer-customer/{id}")]
    public async Task<IActionResult> GetConsumerCustomer([FromRoute] int id)
    {
        var response = mediator.HandleById<ConsumerCustomerResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-consumer-customer")]
    public async Task<IActionResult> UpdateConsumerCustomer([FromBody] UpdateConsumerCustomerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all")]
    public IActionResult GetAll(ConsumerCustomerAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-consumer-customer")]
    public async Task<IActionResult> DeleteConsumerCustomer([FromBody] DeleteConsumerCustomerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
}
