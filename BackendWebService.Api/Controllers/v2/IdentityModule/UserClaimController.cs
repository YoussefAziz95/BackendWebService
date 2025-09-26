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
public class UserClaimController(IMediator mediator) : AppControllerBase
{

    //-------------------------------
    #region UserClaim APIs
    //-------------------------------
    [HttpPost("add-user-claim")]
    public async Task<IActionResult> AddUserClaim([FromBody] AddUserClaimRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-user-claim/{id}")]
    public IActionResult GetUserClaim([FromRoute] int id)
    {
        var response = mediator.HandleById<UserClaimResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-user-claim")]
    public async Task<IActionResult> UpdateUserClaim([FromBody] UpdateUserClaimRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-user-claim")]
    public IActionResult GetAll(UserClaimAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-user-claim")]
    public async Task<IActionResult> DeleteUserClaim([FromBody] DeleteUserClaimRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}
