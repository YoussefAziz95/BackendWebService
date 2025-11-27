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
public class GroupController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region Group APIs
    //-------------------------------
    [HttpPost("add-group")]
    public async Task<IActionResult> AddGroup([FromBody] AddGroupRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-group/{id}")]
    public IActionResult GetGroup([FromRoute] int id)
    {
        var response = mediator.HandleById<GroupResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-group")]
    public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-group")]
    public IActionResult GetAll(GroupAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-group")]
    public async Task<IActionResult> DeleteGroup([FromBody] DeleteGroupRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

}
