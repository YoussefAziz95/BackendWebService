using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class MenuItem : BaseEntity
{
    [Required]
    public int ItemId { get; set; }

    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; }

    [Required]
    public int MenuId { get; set; }

    [ForeignKey(nameof(MenuId))]
    public virtual Menu Menu { get; set; }
}
