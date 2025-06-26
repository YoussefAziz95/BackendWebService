using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("EmailLog")]
public class EmailLog : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Subject { get; set; }

    public string Body { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public int SenderId { get; set; }

    [ForeignKey(nameof(SenderId))]
    public User Sender { get; set; }
}
