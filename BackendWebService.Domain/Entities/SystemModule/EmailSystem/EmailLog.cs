using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

[Table("EmailLog")]
public class EmailLog : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Subject { get; set; }

    public string Body { get; set; }

    public DateTime SentAt { get; set; }

    public int SenderId { get; set; }

    [ForeignKey(nameof(SenderId))]
    public User Sender { get; set; }

}


