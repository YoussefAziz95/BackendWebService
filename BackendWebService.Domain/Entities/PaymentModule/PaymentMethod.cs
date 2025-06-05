using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("PaymentMethod")]
public class PaymentMethod : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int UserId { get; set; }
    [Required]
    [MaxLength(50)]
    public string MethodType { get; set; }
    [Required]
    [MaxLength(50)]
    public string Provider { get; set; }
    [Required]
    [MaxLength(100)]
    public string AccountNumber { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; } // e.g., "Cash", "Credit Card", "PayPal"

    [Required]
    public PaymentEnum Type { get; set; } // Enum instead of multiple boolean flags
    public bool IsDefault { get; set; } = false;
    public DateTime? ExpiryDate { get; set; }
    public bool IsVerified { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}