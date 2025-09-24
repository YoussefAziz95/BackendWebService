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
public class JobController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Job APIs
    //-------------------------------
    [HttpPost("add-job")]
    public async Task<IActionResult> AddJob([FromBody] AddJobRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-job/{id}")]
    public async Task<IActionResult> GetJob([FromRoute] int id)
    {
        var response = mediator.HandleById<JobResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-job")]
    public async Task<IActionResult> UpdateJob([FromBody] UpdateJobRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-job")]
    public IActionResult GetAll(JobAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-job")]
    public async Task<IActionResult> DeleteJob([FromBody] DeleteJobRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region JobVerification APIs
    //-------------------------------
    [HttpPost("add-job-verification")]
    public async Task<IActionResult> AddJobVerification([FromBody] AddJobVerificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-job-verification/{id}")]
    public async Task<IActionResult> GetJobVerification([FromRoute] int id)
    {
        var response = mediator.HandleById<JobVerificationResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-job-verification")]
    public async Task<IActionResult> UpdateJobVerification([FromBody] UpdateJobVerificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-job-verification")]
    public IActionResult GetAll(JobVerificationAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-job-verification")]
    public async Task<IActionResult> DeleteJobVerification([FromBody] DeleteJobVerificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

}
