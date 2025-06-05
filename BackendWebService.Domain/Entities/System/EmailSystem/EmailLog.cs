using Domain;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("EmailLog")]
public class EmailLog : BaseEntity, IEntity, ITimeModification
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime SentAt { get; set; }
    public int SenderId { get; set; }
    [ForeignKey("SenderId")]
    public User Sender { get; set; }
}

