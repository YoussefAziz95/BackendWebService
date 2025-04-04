using Domain;

namespace Application.Contracts.Persistences;

public interface INotificationRepository
{
    Task<int> AddAsync(Notification fullEntity);

    int AddDetailsAsync(string username, int notificationId);
}
