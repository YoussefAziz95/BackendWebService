using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("PortionItem")]
public class PortionItem : BaseEntity, IEntity, ITimeModification
{
    public int PortionId { get; set; }
    [ForeignKey(nameof(PortionId))]
    public Portion Portion { get; set; }

    public int ItemId { get; set; }
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
}
