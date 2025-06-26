using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Job")]
public class Job : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? ExpirationTime { get; set; }

    public bool IsVerified { get; set; } = false;

    // Navigation
    public ICollection<EmployeeAssignment>? EmployeeAssignments { get; set; }
}
