using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("EmployeeAccount")]
public class EmployeeAccount : BaseEntity, IEntity, ITimeModification
{
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; } // Navigation property

    [Required]
    [MaxLength(50)] // Limit role name length

    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}