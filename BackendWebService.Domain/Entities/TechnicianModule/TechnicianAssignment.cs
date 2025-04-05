using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("TechnicianAssignment")]
public class TechnicianAssignment : BaseEntity, IEntity, ITimeModification
{
    public int TechnicianId { get; set; }
    [ForeignKey("TechnicianId")]
    public Technician Technician { get; set; } // Navigation Property  

    [ForeignKey("JobId")]
    public int JobId { get; set; } // FK to Job  

    [Required]
    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public StatusEnum Status { get; set; } // Pending, Accepted, Rejected, Reassigned  

    public DateTime? TechnicianResponseDate { get; set; } // When the technician responds  

    [MaxLength(500)] // Limits admin notes to 500 characters  
    public string? AdminNotes { get; set; } // Optional: Reason for reassignment/rejection  
}