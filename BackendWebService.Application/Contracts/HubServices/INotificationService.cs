using Application.DTOs.Notifications.Request;
using System.Threading.Tasks;

namespace Application.Contracts.HubServices
{
    public interface INotificationService
    {
        Task<bool> SendMessageAsync(AddNotificationRequest request);
    }
}
