using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("BranchEmployee")]
public class BranchEmployee : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [StringLength(100)]
    public string? JobTitle { get; set; } // Optional: Role in branch

    public bool IsActive { get; set; } = true;

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
}
