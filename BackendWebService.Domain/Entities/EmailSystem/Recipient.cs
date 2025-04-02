using System.ComponentModel.DataAnnotations.Schema;

[Table("Recipient")]
public class Recipient : BaseEntity
{
    public int ReciverId { get; set; }
    public int EmailId { get; set; }
    public Actor Reciver { get; set; }
    public EmailLog Email { get; set; }
}

