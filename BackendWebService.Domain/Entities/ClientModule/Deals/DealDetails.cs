using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("DealDetails")]
public class DealDetails : BaseEntity, IEntity, ITimeModification
{
    public int DealId { get; set; }

    public int OfferItemId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal DetailPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ItemPrice { get; set; }

    [ForeignKey(nameof(DealId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Deal Deal { get; set; }

    [ForeignKey(nameof(OfferItemId))]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public OfferItem OfferItem { get; set; }
}
