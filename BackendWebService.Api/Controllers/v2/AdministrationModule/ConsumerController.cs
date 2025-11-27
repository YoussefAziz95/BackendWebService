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
public class ConsumerController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Consumer APIs
    //-------------------------------

    [HttpPost("add-consumer")]
    public async Task<IActionResult> AddConsumer([FromBody] AddConsumerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer/{id}")]
    public IActionResult GetConsumer([FromRoute] int id)
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

    [HttpPost("get-all-consumer")]
    public IActionResult GetAllConsumer(ConsumerAllRequest request)
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
    #endregion

    //-------------------------------
    #region Consumer Account APIs
    //-------------------------------
    [HttpPost("add-consumer-account")]
    public async Task<IActionResult> AddConsumerAccount([FromBody] AddConsumerAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer-account/{id}")]
    public IActionResult GetConsumerAccount([FromRoute] int id)
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

    [HttpPost("get-all-consumer-account")]
    public IActionResult GetAllConsumerAccount(ConsumerAccountAllRequest request)
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
    #endregion

    //-------------------------------
    #region Consumer Customer APIs
    //-------------------------------
    [HttpPost("add-consumer-customer")]
    public async Task<IActionResult> AddConsumerCustomer([FromBody] AddConsumerCustomerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer-customer/{id}")]
    public IActionResult GetConsumerCustomer([FromRoute] int id)
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

    [HttpPost("get-all-consumer-customer")]
    public IActionResult GetAllConsumerCustomer(ConsumerCustomerAllRequest request)
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
    #endregion

    //-------------------------------
    #region Consumer Document APIs
    //-------------------------------
    [HttpPost("add-consumer-document")]
    public async Task<IActionResult> AddConsumerDocument([FromBody] AddConsumerDocumentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-consumer-document/{id}")]
    public IActionResult GetConsumerDocument([FromRoute] int id)
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

    [HttpPost("get-all-consumer-document")]
    public IActionResult GetAllConsumerDocument(ConsumerDocumentAllRequest request)
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
    #endregion
}
