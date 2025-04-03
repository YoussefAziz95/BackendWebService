
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;
[Table("Job")]
public class Job : BaseEntity, IEntity, ITimeModification
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; } // FK to Customer
    public int? AssignedTechnicianId { get; set; } // Nullable, assigned later
    [Required]
    public StatusEnum Status { get; set; } // Enum: Pending, InProgress, Completed, etc.
    [Required, MaxLength(500)]
    public string Description { get; set; }
    [Required]
    public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ScheduledDate { get; set; } // Nullable, if scheduled
    public DateTime? CompletedDate { get; set; } // Nullable, when finished
}

