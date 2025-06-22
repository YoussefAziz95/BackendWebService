using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Transaction")]
public class Transaction : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public PaymentEnum PaymentMethod { get; set; } // renamed: was `PaymentMethodId` but it’s an enum, not FK

    [Required]
    public TransactionEnum Type { get; set; } // removed MaxLength, it's an enum

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public CurrencyEnum Currency { get; set; } // same fix: removed MaxLength

    [Required]
    public StatusEnum Status { get; set; }

    [Required]
    [MaxLength(100)]
    public string ReferenceNumber { get; set; } // Consider adding a unique index

    [MaxLength(500)]
    public string? Notes { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
