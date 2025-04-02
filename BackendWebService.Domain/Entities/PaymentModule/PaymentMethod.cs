using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("PaymentMethod")]
public class PaymentMethod : BaseEntity
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
    public bool IsDefault { get; set; } = false;
    public DateTime? ExpiryDate { get; set; }
    public bool IsVerified { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}