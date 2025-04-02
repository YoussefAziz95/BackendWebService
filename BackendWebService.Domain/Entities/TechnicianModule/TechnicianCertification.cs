using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TechnicianCertification")]
public class TechnicianCertification
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("TechnicianId")]
    public int TechnicianId { get; set; } 

    [Required]
    [MaxLength(150)] // Certification name limit
    public string CertificationName { get; set; } // e.g., "HVAC License", "Electrical Safety Certification"  

    [Required]
    [MaxLength(150)] // Issuing authority name limit
    public string IssuingAuthority { get; set; } // e.g., "National Electrician Board"  

    [Required]
    public DateTime IssuedDate { get; set; }

    public DateTime? ExpirationDate { get; set; } // Nullable if no expiry  

    [Required]
    public StatusEnum Status { get; set; } // Pending, Verified, Expired  

    [MaxLength(500)] // Limits notes to 500 characters
    public string? VerificationNotes { get; set; } // Optional: SuperAdmin verification notes  
}