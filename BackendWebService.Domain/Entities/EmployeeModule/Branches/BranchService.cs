using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("BranchService")]
public class BranchService : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [ForeignKey(nameof(ServiceId))]
    public virtual Service Service { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }

    public bool IsActive { get; set; } = true;
}
