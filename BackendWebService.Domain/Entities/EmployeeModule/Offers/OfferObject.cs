using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("OfferObject")]
public class OfferObject : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int OfferId { get; set; }

    [ForeignKey(nameof(OfferId))]
    public virtual Offer Offer { get; set; }
   
    [Required]
    public int ObjectId { get; set; }

    [Required, MaxLength(100)]
    public string ObjectType { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }
}
