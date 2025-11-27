using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("ConsumerCustomer")]
public class ConsumerCustomer : BaseEntity, IEntity, ITimeModification
{
    public int ConsumerId { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    [ForeignKey(nameof(ConsumerId))]
    public Consumer Consumer { get; set; }
}
