using Application.DTOs.Notification.Request;

namespace Application.Contracts.HubServices
{
    public interface INotificationService
    {
        Task<bool> SendMessageAsync(AddNotificationRequest request);
    }
}
