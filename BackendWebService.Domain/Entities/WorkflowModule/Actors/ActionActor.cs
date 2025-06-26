using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ActionActor")]
public class ActionActor : BaseEntity, IEntity, ITimeModification
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public StatusEnum StatusId { get; set; }
    public ActionEnum ActionType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public int? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public int? TargetEntityId { get; set; }
    public TableNameEnum? TableName { get; set; }
}
