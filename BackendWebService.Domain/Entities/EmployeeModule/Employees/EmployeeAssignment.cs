using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("EmployeeAssignment")]
public class EmployeeAssignment : BaseEntity, IEntity, ITimeModification
{
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; } // Navigation Property  

    [ForeignKey("JobId")]
    public int JobId { get; set; } // FK to Job  

    [Required]
    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public StatusEnum Status { get; set; } // Pending, Accepted, Rejected, Reassigned  

    public DateTime? EmployeeResponseDate { get; set; } // When the employee responds  

    [MaxLength(500)] // Limits admin notes to 500 characters  
    public string? AdminNotes { get; set; } // Optional: Reason for reassignment/rejection  
}