using System.ComponentModel.DataAnnotations.Schema;

[Table("EmailLog")]
public class EmailLog : BaseEntity
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime SentAt { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; }
}

