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
    public PaymentEnum PaymentMethodId { get; set; }
    [Required]
    [MaxLength(50)]
    public TransactionEnum Type { get; set; }
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }
    [Required]
    [MaxLength(10)]
    public CurrencyEnum Currency { get; set; }
    [Required]
    [MaxLength(20)]
    public StatusEnum Status { get; set; }
    [Required]
    [MaxLength(100)]
    public string ReferenceNumber { get; set; }
    [MaxLength(500)]
    public string? Notes { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}