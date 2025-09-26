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
public class CustomerController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Customer APIs
    //-------------------------------
    [HttpPost("add-customer")]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-customer/{id}")]
    public IActionResult GetCustomer([FromRoute] int id)
    {
        var response = mediator.HandleById<CustomerResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-customer")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-customer")]
    public IActionResult GetAllCustomer(CustomerAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-customer")]
    public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion


    //-------------------------------
    #region CustomerPaymentMethod APIs
    //-------------------------------
    [HttpPost("add-customer-payment-method")]
    public async Task<IActionResult> AddCustomerPaymentMethod([FromBody] AddCustomerPaymentMethodRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-customer-payment-method/{id}")]
    public IActionResult GetCustomerPaymentMethod([FromRoute] int id)
    {
        var response = mediator.HandleById<CustomerPaymentMethodResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-customer-payment-method")]
    public async Task<IActionResult> UpdateCustomerPaymentMethod([FromBody] UpdateCustomerPaymentMethodRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-customer-payment-method")]
    public IActionResult GetAllCustomerPaymentMethod(CustomerPaymentMethodAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-customer-payment-method")]
    public async Task<IActionResult> DeleteCustomerPaymentMethod([FromBody] DeleteCustomerPaymentMethodRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region CustomerService APIs
    //-------------------------------
    [HttpPost("add-customer-service")]
    public async Task<IActionResult> AddCustomerService([FromBody] AddCustomerServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-customer-service/{id}")]
    public IActionResult GetCustomerService([FromRoute] int id)
    {
        var response = mediator.HandleById<CustomerServiceResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-customer-service")]
    public async Task<IActionResult> UpdateCustomerService([FromBody] UpdateCustomerServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-customer-service")]
    public IActionResult GetAllCustomerService(CustomerServiceAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-customer-service")]
    public async Task<IActionResult> DeleteCustomerService([FromBody] DeleteCustomerServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
