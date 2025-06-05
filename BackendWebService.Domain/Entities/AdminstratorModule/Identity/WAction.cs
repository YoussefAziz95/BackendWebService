using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("WAction")]
public class WAction : BaseEntity, IEntity, ITimeModification
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public StatusEnum StatusId { get; set; }
    public ActionEnum ActionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public int? TargetEntityId { get; set; }
    public TableNameEnum? TableName { get; set; }
}