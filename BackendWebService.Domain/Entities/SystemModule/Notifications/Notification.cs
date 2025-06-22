using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

[Table("Notification")]
public class Notification : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string KeyMessageTitle { get; set; }

    public string KeyMessageBody { get; set; }

    [Required]
    public NotificationPriority Priority { get; set; }  // changed from string

    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

    public DateTime ExpiryDate { get; set; }

    public int NotifierId { get; set; }

    public int NotifiedId { get; set; }

    [Required]
    public string NotifiedType { get; set; } // Polymorphic: User, Actor, etc.

    public int? NotificationTypeId { get; set; } // Optional FK to type

    public string? NotificationType { get; set; } // Soft string fallback

    public int? NotificationObjectId { get; set; } // e.g. related Offer ID

    public string? NotificationObjectType { get; set; } // e.g. Offer, File, Task

    // Navigation
    public ICollection<NotificationDetail>? Details { get; set; }
}
