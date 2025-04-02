using System.ComponentModel.DataAnnotations.Schema;

[Table("NotificationDetail")]
public class NotificationDetail : BaseEntity
{
    public int NotificationId { get; set; }
    public string Channel { get; set; }
    public int UserId { get; set; }
    public bool IsRead { get; set; }
    public Notification Notification { get; set; }
}

