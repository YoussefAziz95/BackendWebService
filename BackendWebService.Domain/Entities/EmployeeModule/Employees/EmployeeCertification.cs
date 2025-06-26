using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("EmployeeCertification")]
public class EmployeeCertification : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int EmployeeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public virtual Employee Employee { get; set; }

    [Required, MaxLength(150)]
    public string CertificationName { get; set; }

    [Required, MaxLength(150)]
    public string IssuingAuthority { get; set; }

    [Required]
    public DateTime IssuedDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [Required]
    public StatusEnum Status { get; set; }

    [MaxLength(500)]
    public string? VerificationNotes { get; set; }
}
