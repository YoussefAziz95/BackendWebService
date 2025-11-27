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
public class ActorController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Actor APIs
    //-------------------------------
    [HttpPost("add-actor")]
    public async Task<IActionResult> AddActor([FromBody] AddActorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-actor/{id}")]
    public async Task<IActionResult> GetActor([FromRoute] int id)
    {
        var response = mediator.HandleById<ActorResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-actor")]
    public async Task<IActionResult> UpdateActor([FromBody] UpdateActorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-actor")]
    public IActionResult GetAll(ActorAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-actor")]
    public async Task<IActionResult> DeleteActor([FromBody] DeleteActorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
    //-------------------------------
    #region ActionActor APIs
    //-------------------------------
    [HttpPost("add-action-actor")]
    public async Task<IActionResult> AddActionActor([FromBody] AddActionActorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-action-actor/{id}")]
    public async Task<IActionResult> GetActionActor([FromRoute] int id)
    {
        var response = mediator.HandleById<ActionActorResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-action-actor")]
    public async Task<IActionResult> UpdateActionActor([FromBody] UpdateActionActorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-action-actor")]
    public IActionResult GetAll(ActionActorAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-action-actor")]
    public async Task<IActionResult> DeleteActionActor([FromBody] DeleteActionActorRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region ActionObject APIs
    //-------------------------------
    [HttpPost("add-action-object")]
    public async Task<IActionResult> AddActionObject([FromBody] AddActionObjectRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-action-object/{id}")]
    public async Task<IActionResult> GetActionObject([FromRoute] int id)
    {
        var response = mediator.HandleById<ActionObjectResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-action-object")]
    public async Task<IActionResult> UpdateActionObject([FromBody] UpdateActionObjectRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-action-object")]
    public IActionResult GetAll(ActionObjectAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-action-object")]
    public async Task<IActionResult> DeleteActionObject([FromBody] DeleteActionObjectRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
