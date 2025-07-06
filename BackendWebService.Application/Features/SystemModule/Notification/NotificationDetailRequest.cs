namespace Application.Features;
public record NotificationDetailRequest(string Channel, int NotifiedId, bool IsRead = false);