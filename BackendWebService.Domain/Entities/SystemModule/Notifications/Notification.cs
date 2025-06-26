using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Notification")]
public class Notification : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string KeyMessageTitle { get; set; }

    public string KeyMessageBody { get; set; }

    [Required]
    public NotificationPriorityEnum Priority { get; set; }

    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

    public DateTime ExpiryDate { get; set; }

    public int NotifierId { get; set; }

    public int NotifiedId { get; set; }

    [Required]
    public string NotifiedType { get; set; }

    public int? NotificationTypeId { get; set; }
    public string? NotificationType { get; set; }

    public int? NotificationObjectId { get; set; }
    public string? NotificationObjectType { get; set; }

    public ICollection<NotificationDetail>? Details { get; set; }
}
