using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("BranchWorkingHour")]
public class BranchWorkingHour : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    [Required]
    public DayOfWeek DayOfWeek { get; set; } // Enum: Sunday, Monday, etc.

    [Required]
    public TimeSpan OpenTime { get; set; }

    [Required]
    public TimeSpan CloseTime { get; set; }

    public bool IsClosed { get; set; } = false;
}
