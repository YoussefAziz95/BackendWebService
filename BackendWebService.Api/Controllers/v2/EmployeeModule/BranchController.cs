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
public class BranchController(IMediator mediator) : AppControllerBase
{
    //-------------------------------
    #region Branch APIs
    //-------------------------------
    [HttpPost("add-branch")]
    public async Task<IActionResult> AddBranch([FromBody] AddBranchRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-branch/{id}")]
    public IActionResult GetBranch([FromRoute] int id)
    {
        var response = mediator.HandleById<BranchResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-branch")]
    public async Task<IActionResult> UpdateBranch([FromBody] UpdateBranchRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-branch")]
    public IActionResult GetAll(BranchAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-branch")]
    public async Task<IActionResult> DeleteBranch([FromBody] DeleteBranchRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region BranchContact APIs
    //-------------------------------
    [HttpPost("add-branch-contact")]
    public async Task<IActionResult> AddBranchContact([FromBody] AddBranchContactRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-branch-contact/{id}")]
    public IActionResult GetBranchContact([FromRoute] int id)
    {
        var response = mediator.HandleById<BranchContactResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-branch-contact")]
    public async Task<IActionResult> UpdateBranchContact([FromBody] UpdateBranchContactRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-branch-contact")]
    public IActionResult GetAll(BranchContactAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-branch-contact")]
    public async Task<IActionResult> DeleteBranchContact([FromBody] DeleteBranchContactRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion


    //-------------------------------
    #region BranchEmployee APIs
    //-------------------------------
    [HttpPost("add-branch-employee")]
    public async Task<IActionResult> AddBranchEmployee([FromBody] AddBranchEmployeeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-branch-employee/{id}")]
    public IActionResult GetBranchEmployee([FromRoute] int id)
    {
        var response = mediator.HandleById<BranchEmployeeResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-branch-employee")]
    public async Task<IActionResult> UpdateBranchEmployee([FromBody] UpdateBranchEmployeeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-branch-employee")]
    public IActionResult GetAll(BranchEmployeeAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-branch-employee")]
    public async Task<IActionResult> DeleteBranchEmployee([FromBody] DeleteBranchEmployeeRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region BranchLocation APIs
    //-------------------------------
    [HttpPost("add-branch-location")]
    public async Task<IActionResult> AddBranchLocation([FromBody] AddBranchLocationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-branch-location/{id}")]
    public IActionResult GetBranchLocation([FromRoute] int id)
    {
        var response = mediator.HandleById<BranchLocationResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-branch-location")]
    public async Task<IActionResult> UpdateBranchLocation([FromBody] UpdateBranchLocationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-branch-location")]
    public IActionResult GetAll(BranchLocationAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-branch-location")]
    public async Task<IActionResult> DeleteBranchLocation([FromBody] DeleteBranchLocationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region BranchService APIs
    //-------------------------------
    [HttpPost("add-branch-service")]
    public async Task<IActionResult> AddBranchService([FromBody] AddBranchServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-branch-service/{id}")]
    public IActionResult GetBranchService([FromRoute] int id)
    {
        var response = mediator.HandleById<BranchServiceResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-branch-service")]
    public async Task<IActionResult> UpdateBranchService([FromBody] UpdateBranchServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-branch-service")]
    public IActionResult GetAll(BranchServiceAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-branch-service")]
    public async Task<IActionResult> DeleteBranchService([FromBody] DeleteBranchServiceRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region BranchWorkingHour APIs
    //-------------------------------
    [HttpPost("add-branch-working-hour")]
    public async Task<IActionResult> AddBranchWorkingHour([FromBody] AddBranchWorkingHourRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-branch-working-hour/{id}")]
    public IActionResult GetBranchWorkingHour([FromRoute] int id)
    {
        var response = mediator.HandleById<BranchWorkingHourResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-branch-working-hour")]
    public async Task<IActionResult> UpdateBranchWorkingHour([FromBody] UpdateBranchWorkingHourRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-branch-working-hour")]
    public IActionResult GetAll(BranchWorkingHourAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-branch-working-hour")]
    public async Task<IActionResult> DeleteBranchWorkingHour([FromBody] DeleteBranchWorkingHourRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
