using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record NotificationHubResponse([property: Required] string MessageTitle, [property: Required] string MessageBody, string? Priority, string? Status, DateTime? TimeStamp, DateTime? ExpiryDate, bool? IsRead, int? NotifierId, string? Email);