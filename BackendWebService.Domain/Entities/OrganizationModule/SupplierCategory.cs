using Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("SupplierCategory")]
public class SupplierCategory : BaseEntity, IEntity, ITimeModification
{
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
}