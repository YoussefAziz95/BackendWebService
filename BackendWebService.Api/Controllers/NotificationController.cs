using BackendWebService.Api.Base;
using Application.Contracts.HubServices;
using Application.DTOs.Notifications;
using CrossCuttingConcerns.ConfigHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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

