using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Branch : BaseEntity
{
    [Required, StringLength(100)]
    public string FranchiseName { get; set; }

    [StringLength(255)]
    public string? FranchiseSlogan { get; set; }

    [Required, Url]
    public string LogoUrl { get; set; }

    [Required, Phone, StringLength(20)]
    public string PhoneNumber { get; set; }

    [Url]
    public string? WebsiteUrl { get; set; }

    public virtual List<Branch> Cafes { get; set; } = new();

    public virtual List<StorageUnit> StorageUnits { get; set; } = new();

    public virtual List<User> Customers { get; set; } = new();
}
