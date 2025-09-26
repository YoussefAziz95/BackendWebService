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
public class UserGroupController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region UserGroup APIs
    //-------------------------------
    [HttpPost("add-user-group")]
    public async Task<IActionResult> AddUserGroup([FromBody] AddUserGroupRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-user-group/{id}")]
    public IActionResult GetUserGroup([FromRoute] int id)
    {
        var response = mediator.HandleById<UserGroupResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-user-group")]
    public async Task<IActionResult> UpdateUserGroup([FromBody] UpdateUserGroupRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-user-group")]
    public IActionResult GetAll(UserGroupAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-user-group")]
    public async Task<IActionResult> DeleteUserGroup([FromBody] DeleteUserGroupRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
