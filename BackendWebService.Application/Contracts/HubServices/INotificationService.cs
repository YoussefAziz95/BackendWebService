using Application.DTOs.Notifications;

namespace Application.Contracts.HubServices;

public interface INotificationService
{
    Task<bool> SendMessageAsync(AddNotificationRequest request);
}
