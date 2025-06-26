using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("JobVerification")]
public class JobVerification : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int EmployeeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public virtual Employee Employee { get; set; }

    [Required]
    public VerificationEnum Verification { get; set; }

    [Required, MaxLength(10)]
    public string VerificationCode { get; set; }

    [Required]
    public DateTime ExpirationTime { get; set; }

    public bool IsVerified { get; set; } = false;
}
