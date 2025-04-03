using Application.Contracts.HubServices;
using Application.DTOs.Notifications;
using Application.DTOs.Notifications.Request;
using CrossCuttingConcerns.ConfigHub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Api.Base;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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
}

