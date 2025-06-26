using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Inventory")]
public class Inventory : BaseEntity, IEntity, ITimeModification
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }

    public ICollection<StorageUnit> StorageUnits { get; set; }

    public ICollection<Item> Items { get; set; }
}
