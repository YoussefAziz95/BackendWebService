using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Receipt")]
public class Receipt : BaseEntity, IEntity, ITimeModification
{
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [Required]
    public int PaymentMethodId { get; set; }

    [ForeignKey(nameof(PaymentMethodId))]
    public virtual PaymentMethod PaymentMethod { get; set; }

    public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPaid { get; set; }
}
