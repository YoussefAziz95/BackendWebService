

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("TechnicianAccount")]
public class TechnicianAccount : BaseEntity, IEntity, ITimeModification
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