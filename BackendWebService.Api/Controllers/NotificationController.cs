using Application.Contracts.HubServices;
using Application.DTOs.Notification;
using Application.DTOs.Notification.Request;
using CrossCuttingConcerns.ConfigHub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentation.Base;

namespace Presentation.Controllers
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

