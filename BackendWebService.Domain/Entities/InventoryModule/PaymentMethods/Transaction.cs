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
    public PaymentEnum PaymentMethod { get; set; } // Enum (e.g., Cash, Card)

    [Required]
    public TransactionEnum Type { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public CurrencyEnum Currency { get; set; }

    [Required]
    public StatusEnum Status { get; set; }

    [Required, MaxLength(100)]
    public string ReferenceNumber { get; set; } // Should be indexed uniquely

    [MaxLength(500)]
    public string? Notes { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
