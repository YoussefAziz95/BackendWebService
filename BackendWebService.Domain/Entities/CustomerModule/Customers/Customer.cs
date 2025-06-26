using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customer")]
public class Customer : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public bool MFAEnabled { get; set; } = false;

    public RoleEnum Role { get; set; } = RoleEnum.Customer;

    public StatusEnum Status { get; set; } = StatusEnum.Active;

    // Proper navigation properties
    public virtual ICollection<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
    public virtual ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = new List<CustomerPaymentMethod>();
}
