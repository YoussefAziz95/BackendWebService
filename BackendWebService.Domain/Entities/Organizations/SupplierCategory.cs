
using System.ComponentModel.DataAnnotations.Schema;

[Table("SupplierCategory")]
public class SupplierCategory : BaseEntity
{
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
}