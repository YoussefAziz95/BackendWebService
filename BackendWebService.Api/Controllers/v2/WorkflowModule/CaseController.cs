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
public class CaseController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Case APIs
    //-------------------------------
    [HttpPost("add-case")]
    public async Task<IActionResult> AddCase([FromBody] AddCaseRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-case/{id}")]
    public async Task<IActionResult> GetCase([FromRoute] int id)
    {
        var response = mediator.HandleById<CaseResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-case")]
    public async Task<IActionResult> UpdateCase([FromBody] UpdateCaseRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-case")]
    public IActionResult GetAll(CaseAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-case")]
    public async Task<IActionResult> DeleteCase([FromBody] DeleteCaseRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region CaseAction APIs
    //-------------------------------
    [HttpPost("add-case-action")]
    public async Task<IActionResult> AddCaseAction([FromBody] AddCaseActionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-case-action/{id}")]
    public async Task<IActionResult> GetCaseAction([FromRoute] int id)
    {
        var response = mediator.HandleById<CaseActionResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-case-action")]
    public async Task<IActionResult> UpdateCaseAction([FromBody] UpdateCaseActionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-case-action")]
    public IActionResult GetAll(CaseActionAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-case-action")]
    public async Task<IActionResult> DeleteCaseAction([FromBody] DeleteCaseActionRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
