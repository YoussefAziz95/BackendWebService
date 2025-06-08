
using Domain;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Administrator")]
public class Administrator : BaseEntity, IEntity, ITimeModification
{
    public required int UserId { get; set; }
    [ForeignKey("UserId")]
    public required User User { get; set; }
    public RoleEnum MainRole => RoleEnum.SuperAdmin;
    public OrganizationEnum Role { get; set; } = OrganizationEnum.Organization;
    public string Attributes { get; set; } // Consider using a JSON column
    public StatusEnum Status { get; set; } = StatusEnum.Active;
}