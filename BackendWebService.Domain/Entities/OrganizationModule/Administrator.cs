
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Administrator")]
public class Administrator : BaseEntity, IEntity, ITimeModification
{
    public int UserId { get; set; }
    [ForeignKey("ActorId")]
    public virtual User User { get; set; }

    public int OrganizationId { get; set; }
    [ForeignKey("OrganizationId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Organization Organization { get; set; }

    public OrganizationEnum Role { get; set; } = OrganizationEnum.Administrator;
    public string Attributes { get; set; } // Consider using a JSON column
    public StatusEnum Status { get; set; } = StatusEnum.Active;
}