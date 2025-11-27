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
public class EmployeeController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Employee APIs
    //-------------------------------
    [HttpPost("add-employee")]
    public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-employee/{id}")]
    public IActionResult GetEmployee([FromRoute] int id)
    {
        var response = mediator.HandleById<EmployeeResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-employee")]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-employee")]
    public IActionResult GetAll(EmployeeAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-employee")]
    public async Task<IActionResult> DeleteEmployee([FromBody] DeleteEmployeeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region EmployeeAccount APIs
    //-------------------------------
    [HttpPost("add-employee-account")]
    public async Task<IActionResult> AddEmployeeAccount([FromBody] AddEmployeeAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-employee-account/{id}")]
    public IActionResult GetEmployeeAccount([FromRoute] int id)
    {
        var response = mediator.HandleById<EmployeeAccountResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-employee-account")]
    public async Task<IActionResult> UpdateEmployeeAccount([FromBody] UpdateEmployeeAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-employee-account")]
    public IActionResult GetAll(EmployeeAccountAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-employee-account")]
    public async Task<IActionResult> DeleteEmployeeAccount([FromBody] DeleteEmployeeAccountRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region EmployeeAssignment APIs
    //-------------------------------
    [HttpPost("add-employee-assignment")]
    public async Task<IActionResult> AddEmployeeAssignment([FromBody] AddEmployeeAssignmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-employee-assignment/{id}")]
    public IActionResult GetEmployeeAssignment([FromRoute] int id)
    {
        var response = mediator.HandleById<EmployeeAssignmentResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-employee-assignment")]
    public async Task<IActionResult> UpdateEmployeeAssignment([FromBody] UpdateEmployeeAssignmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-employee-assignment")]
    public IActionResult GetAll(EmployeeAssignmentAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-employee-assignment")]
    public async Task<IActionResult> DeleteEmployeeAssignment([FromBody] DeleteEmployeeAssignmentRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region EmployeeCertification APIs
    //-------------------------------
    [HttpPost("add-employee-certification")]
    public async Task<IActionResult> AddEmployeeCertification([FromBody] AddEmployeeCertificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-employee-certification/{id}")]
    public IActionResult GetEmployeeCertification([FromRoute] int id)
    {
        var response = mediator.HandleById<EmployeeCertificationResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-employee-certification")]
    public async Task<IActionResult> UpdateEmployeeCertification([FromBody] UpdateEmployeeCertificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-employee-certification")]
    public IActionResult GetAll(EmployeeCertificationAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-employee-certification")]
    public async Task<IActionResult> DeleteEmployeeCertification([FromBody] DeleteEmployeeCertificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region EmployeeJob APIs
    //-------------------------------
    [HttpPost("add-employee-job")]
    public async Task<IActionResult> AddEmployeeJob([FromBody] AddEmployeeJobRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-employee-job/{id}")]
    public IActionResult GetEmployeeJob([FromRoute] int id)
    {
        var response = mediator.HandleById<EmployeeJobResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-employee-job")]
    public async Task<IActionResult> UpdateEmployeeJob([FromBody] UpdateEmployeeJobRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-employee-job")]
    public IActionResult GetAll(EmployeeJobAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-employee-job")]
    public async Task<IActionResult> DeleteEmployeeJob([FromBody] DeleteEmployeeJobRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

}
