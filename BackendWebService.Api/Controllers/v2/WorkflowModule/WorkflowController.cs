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
public class WorkflowController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Workflow APIs
    //-------------------------------
    [HttpPost("add-workflow")]
    public async Task<IActionResult> AddWorkflow([FromBody] AddWorkflowRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-workflow/{id}")]
    public async Task<IActionResult> GetWorkflow([FromRoute] int id)
    {
        var response = mediator.HandleById<WorkflowResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-workflow")]
    public async Task<IActionResult> UpdateWorkflow([FromBody] UpdateWorkflowRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-workflow")]
    public IActionResult GetAll(WorkflowAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-workflow")]
    public async Task<IActionResult> DeleteWorkflow([FromBody] DeleteWorkflowRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region WorkflowCycle APIs
    //-------------------------------
    [HttpPost("add-workflow-cycle")]
    public async Task<IActionResult> AddWorkflowCycle([FromBody] AddWorkflowCycleRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-workflow-cycle/{id}")]
    public async Task<IActionResult> GetWorkflowCycle([FromRoute] int id)
    {
        var response = mediator.HandleById<WorkflowCycleResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-workflow-cycle")]
    public async Task<IActionResult> UpdateWorkflowCycle([FromBody] UpdateWorkflowCycleRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-workflow-cycle")]
    public IActionResult GetAll(WorkflowCycleAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-workflow-cycle")]
    public async Task<IActionResult> DeleteWorkflowCycle([FromBody] DeleteWorkflowCycleRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
