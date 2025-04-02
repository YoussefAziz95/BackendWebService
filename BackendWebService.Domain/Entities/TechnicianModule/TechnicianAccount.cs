
using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TechnicianAccount")]
public class TechnicianAccount : BaseEntity
{
    public int TechnicianId { get; set; }
    [ForeignKey("TechnicianId")]
    public Technician Technician { get; set; } // Navigation property

    [Required]
    [MaxLength(50)] // Limit role name length

    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}