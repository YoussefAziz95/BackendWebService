using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Workflow")]
public class Workflow : BaseEntity, IEntity, ITimeModification
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public int? CompanyId { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; }

    public IList<WorkflowCycle>? WorkflowCycles { get; set; }
}
