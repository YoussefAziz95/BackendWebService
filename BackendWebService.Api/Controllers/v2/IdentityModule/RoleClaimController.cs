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
public class RoleClaimController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region RoleClaim APIs
    //-------------------------------
    [HttpPost("add-role-claim")]
    public async Task<IActionResult> AddRoleClaim([FromBody] AddRoleClaimRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-role-claim/{id}")]
    public IActionResult GetRoleClaim([FromRoute] int id)
    {
        var response = mediator.HandleById<RoleClaimResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-role-claim")]
    public async Task<IActionResult> UpdateRoleClaim([FromBody] UpdateRoleClaimRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-role-claim")]
    public IActionResult GetAll(RoleClaimAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-role-claim")]
    public async Task<IActionResult> DeleteRoleClaim([FromBody] DeleteRoleClaimRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
