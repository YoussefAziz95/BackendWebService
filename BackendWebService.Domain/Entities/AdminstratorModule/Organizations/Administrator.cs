using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Administrator")]
public class Administrator : BaseEntity, IEntity, ITimeModification
{
    public required int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public required User User { get; set; }

    public RoleEnum MainRole => RoleEnum.SuperAdmin;

    public OrganizationEnum OrganizationType { get; set; } = OrganizationEnum.Organization;

    public string Attributes { get; set; } // Recommend: Use JSON column and custom parsing

    public StatusEnum Status { get; set; } = StatusEnum.Active;
}
