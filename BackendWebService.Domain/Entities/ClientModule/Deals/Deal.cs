using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Deal")]
public class Deal : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int OrganizationId { get; set; }

    [Required]
    public int OfferId { get; set; }

    public int? UserId { get; set; } // Optional

    [Required]
    public int CompanyVendorId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TotalPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? FinalPrice { get; set; }

    public int? Vat { get; set; }

    public int? Discount { get; set; }

    public int? Quantity { get; set; }

    public int? StatusId { get; set; }

    // Navigation properties
    [ForeignKey(nameof(OfferId))]
    public Offer Offer { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [ForeignKey(nameof(OrganizationId))]
    public Organization Organization { get; set; }

    public ICollection<DealDocument> DealDocuments { get; set; }
    public ICollection<DealDetails> DealDetails { get; set; }
}
