using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("NotificationDetail")]
public class NotificationDetail : BaseEntity, IEntity, ITimeModification
{
    public int NotificationId { get; set; }
    public string Channel { get; set; }
    public int UserId { get; set; }
    public bool IsRead { get; set; }
    public DateTime ExpiryDate { get; set; }
    public Notification Notification { get; set; }
}

