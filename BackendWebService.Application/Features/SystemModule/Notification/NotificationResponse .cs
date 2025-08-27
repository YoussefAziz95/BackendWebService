using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record NotificationResponse(
string KeyMessageTitle,
string KeyMessageBody,
NotificationPriorityEnum Priority,
DateTime ExpiryDate,
int NotifierId,
int NotifiedId,
string NotifiedType,
int? NotificationTypeId,
string? NotificationType,
int? NotificationObjectId,
string? NotificationObjectType,
List<NotificationDetailResponse> Details);