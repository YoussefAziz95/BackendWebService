using Api.Base;
using Application.Contracts.Features;
using Application.Contracts.HubServices;
using Application.Features;
using CrossCuttingConcerns.ConfigHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers.v2;


[ApiController]
[AllowAnonymous]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class NotificationController(IMediator mediator, INotificationService notificationService, IHubContext<NotificationHub> notificationHub) : AppControllerBase
{

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] AddNotificationRequest message)
    {
        await notificationService.SendMessageAsync(message);
        return Ok();
    }

    //-------------------------------
    #region Notification APIs
    //-------------------------------
    [HttpPost("add-notification")]
    public async Task<IActionResult> AddNotification([FromBody] AddNotificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-notification/{id}")]
    public async Task<IActionResult> GetNotification([FromRoute] int id)
    {
        var response = mediator.HandleById<NotificationResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-notification")]
    public async Task<IActionResult> UpdateNotification([FromBody] UpdateNotificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-notification")]
    public IActionResult GetAll(NotificationAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-notification")]
    public async Task<IActionResult> DeleteNotification([FromBody] DeleteNotificationRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion

    //-------------------------------
    #region NotificationDetail APIs
    //-------------------------------
    [HttpPost("add-notification-detail")]
    public async Task<IActionResult> AddNotificationDetail([FromBody] AddNotificationDetailRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpGet("get-notification-detail/{id}")]
    public async Task<IActionResult> GetNotificationDetail([FromRoute] int id)
    {
        var response = mediator.HandleById<NotificationDetailResponse>(id);
        return NewResult(response);
    }

    [HttpPut("update-notification-detail")]
    public async Task<IActionResult> UpdateNotificationDetail([FromBody] UpdateNotificationDetailRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }

    [HttpPost("get-all-notification-detail")]
    public IActionResult GetAll(NotificationDetailAllRequest request)
    {
        var response = mediator.Handle(request);
        return NewResult(response);
    }

    [HttpPost("delete-notification-detail")]
    public async Task<IActionResult> DeleteNotificationDetail([FromBody] DeleteNotificationDetailRequest request)
    {
        var response = await mediator.HandleAsync(request);
        return NewResult(response);
    }
    #endregion
}

