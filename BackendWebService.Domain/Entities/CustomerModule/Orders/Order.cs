using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Order")]
public class Order : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int TableId { get; set; }

    [ForeignKey(nameof(TableId))]
    public virtual BranchContact Table { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Tax { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Service { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [Required, MaxLength(100)]
    public string OrderName { get; set; }
}
