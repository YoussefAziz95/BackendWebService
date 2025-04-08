
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Recipient")]
public class Recipient : BaseEntity, IEntity, ITimeModification
{
    public int ReceiverId { get; set; }
    public int EmailId { get; set; }

    [ForeignKey(nameof(Actor))]
    public Actor Reciver { get; set; }

    [ForeignKey("EmailId")]
    public EmailLog Email { get; set; }
}

