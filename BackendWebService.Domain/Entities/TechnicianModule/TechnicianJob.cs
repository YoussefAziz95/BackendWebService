using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TechnicianJob")]
public class TechnicianJob : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("TechnicianId")]
    public int TechnicianId { get; set; }

    [ForeignKey("JobId")]
    public int JobId { get; set; } // FK to Job  

    [Required]
    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public StatusEnum Status { get; set; } // Pending, Accepted, Rejected, Completed  

    public DateTime? CompletionDate { get; set; } // Nullable for ongoing jobs  

    [MaxLength(500)]
    public string? Notes { get; set; } // Optional admin or technician notes  
}