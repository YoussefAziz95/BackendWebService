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
public class ServiceController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Service APIs
    //-------------------------------
    [HttpPost("add-service")]
    public async Task<IActionResult> AddService([FromBody] AddServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-service/{id}")]
    public async Task<IActionResult> GetService([FromRoute] int id)
    {
        var response = mediator.HandleById<ServiceResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-service")]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-service")]
    public IActionResult GetAll(ServiceAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-service")]
    public async Task<IActionResult> DeleteService([FromBody] DeleteServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region EmployeeService APIs
    //-------------------------------
    [HttpPost("add-employee-service")]
    public async Task<IActionResult> AddEmployeeService([FromBody] AddEmployeeServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-employee-service/{id}")]
    public async Task<IActionResult> GetEmployeeService([FromRoute] int id)
    {
        var response = mediator.HandleById<EmployeeServiceResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-employee-service")]
    public async Task<IActionResult> UpdateEmployeeService([FromBody] UpdateEmployeeServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-employee-service")]
    public IActionResult GetAll(EmployeeServiceAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-employee-service")]
    public async Task<IActionResult> DeleteEmployeeService([FromBody] DeleteEmployeeServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region TimeSlot APIs
    //-------------------------------
    [HttpPost("add-time-slot")]
    public async Task<IActionResult> AddTimeSlot([FromBody] AddTimeSlotRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-time-slot/{id}")]
    public async Task<IActionResult> GetTimeSlot([FromRoute] int id)
    {
        var response = mediator.HandleById<TimeSlotResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-time-slot")]
    public async Task<IActionResult> UpdateTimeSlot([FromBody] UpdateTimeSlotRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-time-slot")]
    public IActionResult GetAll(TimeSlotAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-time-slot")]
    public async Task<IActionResult> DeleteTimeSlot([FromBody] DeleteTimeSlotRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
