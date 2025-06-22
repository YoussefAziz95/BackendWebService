using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("ConsumerCustomer")]
public class ConsumerCustomer : BaseEntity, IEntity, ITimeModification
{
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Consumer Supplier { get; set; }
}