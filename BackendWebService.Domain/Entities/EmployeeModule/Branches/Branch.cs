using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Branch")]
public class Branch : BaseEntity, IEntity, ITimeModification
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

    public virtual List<Branch> Cafes { get; set; } 

    public virtual List<StorageUnit> StorageUnits { get; set; } 

    public virtual List<User> Customers { get; set; } 
}
