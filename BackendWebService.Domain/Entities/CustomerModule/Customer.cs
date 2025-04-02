using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customer")]
public class Customer : BaseEntity
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [Required, Phone, MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public bool MFAEnabled { get; set; } = false;
    public RoleEnum Role { get; set; } = RoleEnum.Customer;  // Default role
    public StatusEnum Status { get; set; } = StatusEnum.Active;
}
