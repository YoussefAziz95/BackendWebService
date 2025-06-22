using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("JobVerification")]
public class JobVerification
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public VerificationEnum Verification { get; set; } // Enum: EmailLog or Phone

    [Required, MaxLength(10)]
    public string VerificationCode { get; set; }  // OTP for verification

    public DateTime ExpirationTime { get; set; }

    public bool IsVerified { get; set; } = false;
}