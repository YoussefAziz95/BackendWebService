using Application.Contracts.Persistence.Notifications;
using Application.Contracts.Proxy;
using Application.DTOs.Notifications;
using CrossCuttingConcerns.ConfigHub;

using Microsoft.AspNetCore.SignalR;

namespace Api.Proxy
{
    public class NotificationProxy : INotificationProxy<NotificationHubResponse>
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly INotificationRepository _notificationRepository;

        public NotificationProxy(IHubContext<NotificationHub> hubContext, INotificationRepository notificationRepository)
        {
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;
        }
        public async Task NotifyAsync(string message, int notificationId, string[] NotifiedUserName, NotificationHubResponse response)
        {

            var connectionIds = NotificationHub.GetConnection(NotifiedUserName);
            foreach (var connectionId in connectionIds)
            {
                _notificationRepository.AddDetailsAsync(connectionId.Key, notificationId);
                if (connectionId.Value is not null)
                {
                    await _hubContext.Clients.Client(connectionId.Value).SendAsync(message, response);
                }
            }
        }

    }
}
