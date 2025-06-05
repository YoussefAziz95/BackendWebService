using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("Customer")]
public class Customer : User
{

    [Required, Phone, MaxLength(20)]
    public bool MFAEnabled { get; set; } = false;
    public RoleEnum Role { get; set; } = RoleEnum.Customer;  // Default role
    public StatusEnum Status { get; set; } = StatusEnum.Active;
    public virtual ICollection<CustomerProperty> CustomerProperties { get; set; }
}
