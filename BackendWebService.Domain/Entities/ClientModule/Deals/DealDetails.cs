using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class DealDetails : BaseEntity
{
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal DetailPrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal ItemPrice { get; set; }

    public int DealId { get; set; }
    public int OfferItemId { get; set; }

    // Navigation properties
    public Deal Deal { get; set; }
    public OfferItem OfferItem { get; set; }
}
