using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("CustomerAccount")]
public class CustomerAccount : BaseEntity
{
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    [EmailAddress, StringLength(100)]
    public string? Email { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    [Required, StringLength(100)]
    public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
    [Required, StringLength(100)]
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    public bool IsSocialLogin { get; set; } = false;
    [StringLength(50)]
    public string? SocialProvider { get; set; }
    [StringLength(100)]
    public string? SocialProviderId { get; set; }
    public bool TwoFactorEnabled { get; set; } = false;
    public bool LockoutEnabled { get; set; } = true;
    public DateTimeOffset? LockoutEnd { get; set; }
    public int AccessFailedCount { get; set; } = 0;
    [Required, StringLength(20)]
    public string AccountStatus { get; set; } = "Active";  // Default to "Active"
    [StringLength(200)]
    public string? AccountStatusReason { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
}
