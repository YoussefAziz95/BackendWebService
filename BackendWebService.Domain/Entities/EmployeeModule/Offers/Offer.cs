using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Offer")]
public class Offer : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int OrganizationId { get; set; }

    [Required, StringLength(255)]
    public string Name { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [StringLength(10)]
    public string? Extention { get; set; } = ".txt";

    [Required, StringLength(50)]
    public string Code { get; set; }

    public bool IsMultiple { get; set; } = false;

    public bool IsLocal { get; set; } = false;

    [Required]
    public AccessEnum AccessType { get; set; }

    [Required]
    public CurrencyEnum Currency { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int SpecificationsFileId { get; set; }

    public string? RichText { get; set; }

    // Navigation
    public virtual List<Criteria> Criterias { get; set; } 
    public virtual List<OfferItem> OfferItems { get; set; } 
    public virtual List<OfferObject> OfferObjects { get; set; } 
}
