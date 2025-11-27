namespace Application.Contracts.Persistence;

public interface INotificationRepository
{
    int AddAsync(Notification fullEntity);

    int AddDetailsAsync(string username, int notificationId);
}
