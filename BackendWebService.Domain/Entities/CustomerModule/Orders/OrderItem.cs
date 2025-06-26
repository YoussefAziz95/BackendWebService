using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("OrderItem")]
public class OrderItem : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; }

    [Required]
    public int ItemId { get; set; }

    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    [Required]
    public DateTime ExpectedTime { get; set; }
}
