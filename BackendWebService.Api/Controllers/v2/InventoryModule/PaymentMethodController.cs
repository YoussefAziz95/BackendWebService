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
public class PaymentMethodController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region PaymentMethod APIs
    //-------------------------------
    [HttpPost("add-payment-method")]
    public async Task<IActionResult> AddPaymentMethod([FromBody] AddPaymentMethodRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-payment-method/{id}")]
    public IActionResult GetPaymentMethod([FromRoute] int id)
    {
        var response = mediator.HandleById<PaymentMethodResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-payment-method")]
    public async Task<IActionResult> UpdatePaymentMethod([FromBody] UpdatePaymentMethodRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-payment-method")]
    public IActionResult GetAll(PaymentMethodAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-payment-method")]
    public async Task<IActionResult> DeletePaymentMethod([FromBody] DeletePaymentMethodRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region Transaction APIs
    //-------------------------------
    [HttpPost("add-transaction")]
    public async Task<IActionResult> AddTransaction([FromBody] AddTransactionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-transaction/{id}")]
    public IActionResult GetTransaction([FromRoute] int id)
    {
        var response = mediator.HandleById<TransactionResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-transaction")]
    public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-transaction")]
    public IActionResult GetAll(TransactionAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-transaction")]
    public async Task<IActionResult> DeleteTransaction([FromBody] DeleteTransactionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
