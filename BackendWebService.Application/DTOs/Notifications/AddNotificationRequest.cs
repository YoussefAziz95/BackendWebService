using BackendWebService.Application.Profiles;
using Domain;
using System;
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs.Notifications;

public class AddNotificationRequest : ICreateMapper<Notification>
{
    [Required]
    public string MessageTitle { get; set; }
    [Required]
    public string MessageBody { get; set; }
    public string Priority { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public DateTime ExpiryDate { get; set; }
    public int NotifierId { get; set; }
    public int NotifiedId { get; set; }
    public string NotifiedType { get; set; }
    public int? NotificationTypeId { get; set; }
    public string NotificationType { get; set; }
    public int? NotificationObjectId { get; set; }
    public string NotificationObjectType { get; set; }
    public int? NotificationObjectTypeId { get; set; }

}
