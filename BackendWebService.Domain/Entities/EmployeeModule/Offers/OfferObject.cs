using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class OfferObject : BaseEntity
{
    [Required]
    public int OfferId { get; set; }

    [Required]
    public int ObjectId { get; set; }

    [Required, MaxLength(100)]
    public string ObjectType { get; set; }

    // Navigation Property
    [ForeignKey(nameof(OfferId))]
    public Offer Offer { get; set; }
}
