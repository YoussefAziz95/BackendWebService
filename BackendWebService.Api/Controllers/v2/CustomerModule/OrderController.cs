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
public class OrderController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Order APIs
    //-------------------------------
    [HttpPost("add-order")]
    public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-order/{id}")]
    public async Task<IActionResult> GetOrder([FromRoute] int id)
    {
        var response = mediator.HandleById<OrderResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-order")]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-order")]
    public IActionResult GetAll(OrderAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-order")]
    public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region OrderItem APIs
    //-------------------------------
    [HttpPost("add-order-item")]
    public async Task<IActionResult> AddOrderItem([FromBody] AddOrderItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-order-item/{id}")]
    public async Task<IActionResult> GetOrderItem([FromRoute] int id)
    {
        var response = mediator.HandleById<OrderItemResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-order-item")]
    public async Task<IActionResult> UpdateOrderItem([FromBody] UpdateOrderItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-order-item")]
    public IActionResult GetAll(OrderItemAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-order-item")]
    public async Task<IActionResult> DeleteOrderItem([FromBody] DeleteOrderItemRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Receipt APIs
    //-------------------------------
    [HttpPost("add-receipt")]
    public async Task<IActionResult> AddReceipt([FromBody] AddReceiptRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-receipt/{id}")]
    public async Task<IActionResult> GetReceipt([FromRoute] int id)
    {
        var response = mediator.HandleById<ReceiptResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-receipt")]
    public async Task<IActionResult> UpdateReceipt([FromBody] UpdateReceiptRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-receipt")]
    public IActionResult GetAll(ReceiptAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-receipt")]
    public async Task<IActionResult> DeleteReceipt([FromBody] DeleteReceiptRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
