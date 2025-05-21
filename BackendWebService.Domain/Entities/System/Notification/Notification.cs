using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Notification")]
public class Notification : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string KeyMessageTitle { get; set; }
    public string KeyMessageBody { get; set; }
    public string Priority { get; set; }
    public DateTime TimeStamp { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int NotifierId { get; set; }
    public int NotifiedId { get; set; }
    public string NotifiedType { get; set; }
    public int? NotificationTypeId { get; set; }
    public string NotificationType { get; set; }
    public int? NotificationObjectId { get; set; }
    public string NotificationObjectType { get; set; }
}