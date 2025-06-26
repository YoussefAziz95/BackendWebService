using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("OfferItem")]
public class OfferItem : BaseEntity, IEntity, ITimeModification
{
    [Required, Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Range(1, int.MaxValue)]
    public int? RequiredAmount { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [ForeignKey(nameof(ServiceId))]
    public Service Service { get; set; }

    [Required]
    public int OfferId { get; set; }

    [ForeignKey(nameof(OfferId))]
    public Offer Offer { get; set; }
}
