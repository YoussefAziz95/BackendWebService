using Api.Base;
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
public class NotificationController : AppControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService, IHubContext<NotificationHub> notificationHub)
    {
        _notificationService = notificationService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] AddNotificationRequest message)
    {
        await _notificationService.SendMessageAsync(message);
        return Ok();
    }
}

