using Domain;
using System.ComponentModel.DataAnnotations.Schema;

[Table("SupplierCategory")]
public class SupplierCategory : BaseEntity, IEntity, ITimeModification
{
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public Supplier Supplier { get; set; } // ✅ FIXED: was wrongly mapped to Consumer
}
