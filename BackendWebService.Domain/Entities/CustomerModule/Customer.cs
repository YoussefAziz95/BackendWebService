using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Customer")]
public class Customer : BaseEntity, IEntity, ITimeModification
{
    public int UserId { get; set; }
    [ForeignKey("ActorId")]
    public virtual User User { get; set; }

    [Required, Phone, MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public bool MFAEnabled { get; set; } = false;
    public RoleEnum Role { get; set; } = RoleEnum.Customer;  // Default role
    public StatusEnum Status { get; set; } = StatusEnum.Active;
}
