using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class OfferItem : BaseEntity
{
    [Required, Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Range(1, int.MaxValue)]
    public int? RequiredAmount { get; set; } // Nullable, only needed in some cases

    [Required]
    public int MaterialId { get; set; }

    [Required]
    public int OfferId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(MaterialId))]
    public Material Material { get; set; }

    [ForeignKey(nameof(OfferId))]
    public Offer Offer { get; set; }
}
