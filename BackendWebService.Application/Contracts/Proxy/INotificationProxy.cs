namespace Application.Contracts.Proxy;

public interface INotificationProxy<T>
{
    Task NotifyAsync(string message, int notificationId, string[] NotifiedUserName, T response);
}
