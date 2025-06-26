using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Client")]
public class Client : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public bool MFAEnabled { get; set; } = false;

    public RoleEnum Role { get; set; } = RoleEnum.Customer;

    public StatusEnum Status { get; set; } = StatusEnum.Active;

    public virtual ICollection<ClientProperty> ClientProperties { get; set; }
}
