using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Recipient")]
public class Recipient : BaseEntity, IEntity, ITimeModification
{
    public int ReceiverId { get; set; }

    public int EmailId { get; set; }

    [ForeignKey(nameof(ReceiverId))]
    public Actor Reciver { get; set; }

    [ForeignKey(nameof(EmailId))]
    public EmailLog Email { get; set; }

}


