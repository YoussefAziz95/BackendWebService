using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("ConsumerCustomer")]
public class ConsumerCustomer : BaseEntity, IEntity, ITimeModification
{
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public Consumer Supplier { get; set; }
}
