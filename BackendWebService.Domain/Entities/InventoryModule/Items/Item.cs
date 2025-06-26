using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Item")]
public class Item : BaseEntity, IEntity, ITimeModification
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }

    public int PreparationTimeMinutes { get; set; }

    public virtual ICollection<PortionItem> PortionItems { get; set; }
}
