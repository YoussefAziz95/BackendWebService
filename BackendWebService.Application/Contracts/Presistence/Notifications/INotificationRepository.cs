namespace Application.Contracts.Persistence;

public interface INotificationRepository
{
    Task<int> AddAsync(Notification fullEntity);

    int AddDetailsAsync(string username, int notificationId);
}
