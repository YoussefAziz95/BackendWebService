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
public class ConsumerDocumentController(IMediator mediator, IUnitOfWork unitOfWork) : AppControllerBase
{

    [HttpPost("add-consumer-document")]
    public async Task<IActionResult> AddConsumerDocument([FromBody] AddConsumerDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer-document/{id}")]
    public async Task<IActionResult> GetConsumerDocument([FromRoute] int id)
    {
        var response = mediator.HandleById<ConsumerDocumentResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-consumer-document")]
    public async Task<IActionResult> UpdateConsumerDocument([FromBody] UpdateConsumerDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all")]
    public IActionResult GetAll(ConsumerDocumentAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-consumer-document")]
    public async Task<IActionResult> DeleteConsumerDocument([FromBody] DeleteConsumerDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
}
