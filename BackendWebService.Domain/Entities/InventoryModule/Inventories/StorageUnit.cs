using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("StorageUnit")]
public class StorageUnit : BaseEntity, IEntity, ITimeModification
{
    public int InventoryId { get; set; }
    [ForeignKey("InventoryId")]
    public virtual Inventory Inventory { get; set; }

    public int? PortionTypeId { get; set; }
    [ForeignKey("PortionTypeId")]
    public virtual PortionType? PortionType { get; set; }

    [Required]
    public int FullQuantity { get; set; }

    [Required]
    public UnitEnum Unit { get; set; } // Enum: Kg, Litre, Box, etc.
}
