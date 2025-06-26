using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("BranchLocation")]
public class BranchLocation : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    [MaxLength(255)]
    public string? Street { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    [Required, Range(-90, 90)]
    public double Latitude { get; set; }

    [Required, Range(-180, 180)]
    public double Longitude { get; set; }

    public string? Notes { get; set; }
}
