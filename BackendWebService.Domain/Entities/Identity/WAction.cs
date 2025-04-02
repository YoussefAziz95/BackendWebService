
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

[Table("WAction")]
public class WAction : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }

    public StatusEnum StatusId { get; set; }
    public ActionEnum ActionType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }
    public int? TargetEntityId { get; set; }
    public string? TargetEntityType { get; set; }
}