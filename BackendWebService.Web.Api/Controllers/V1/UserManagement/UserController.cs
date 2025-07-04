﻿using Asp.Versioning;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.RefreshUserTokenCommand;
using Application.Features.Users.Commands.RequestLogout;
using Application.Features.Users.Queries.GenerateUserToken;
using Application.Features.Users.Queries.TokenRequest;
using WebFramework.BaseController;
using WebFramework.Swagger;
using WebFramework.WebExtensions;
using Mediator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1.UserManagement;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/User")]
public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> CreateUser(UserCreateCommand model)
    {
        var command = await _mediator.Send(model);

        return base.IResponse(command);
    }


    [HttpPost("TokenRequest")]
    public async Task<IActionResult> TokenRequest(UserTokenRequestQuery model)
    {
        var query = await _mediator.Send(model);

        return base.IResponse(query);
    }

    [HttpPost("LoginConfirmation")]
    public async Task<IActionResult> ValidateUser(GenerateUserTokenQuery model)
    {
        var result = await _mediator.Send(model);

        return base.IResponse(result);
    }

    [HttpPost("RefreshSignIn")]
    [RequireTokenWithoutAuthorization]
    public async Task<IActionResult> RefreshUserToken(RefreshUserTokenCommand model)
    {
        var checkCurrentAccessTokenValidity =await HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);

        if (checkCurrentAccessTokenValidity.Succeeded)
            return BadRequest("Current access token is valid. No need to refresh");

        var newTokenResult = await _mediator.Send(model);

        return base.IResponse(newTokenResult);
    }

    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> RequestLogout()
    {
        var commandResult = await _mediator.Send(new RequestLogoutCommand(base.UserId));

        return base.IResponse(commandResult);
    }
}