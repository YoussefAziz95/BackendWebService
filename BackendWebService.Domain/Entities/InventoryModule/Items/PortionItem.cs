using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class PortionItem : BaseEntity
{
    [Required]
    public int PortionId { get; set; }

    [ForeignKey(nameof(PortionId))]
    public Portion Portion { get; set; }

    [Required]
    public int ItemId { get; set; }

    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
}
