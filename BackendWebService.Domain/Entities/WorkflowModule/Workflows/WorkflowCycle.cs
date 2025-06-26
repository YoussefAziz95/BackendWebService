using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("WorkflowCycle")]
public class WorkflowCycle : BaseEntity, IEntity, ITimeModification
{
    [Required, Range(1, int.MaxValue)]
    public int ActionOrder { get; set; }

    [MaxLength(100)]
    public string? ActionType { get; set; }

    public bool Mandatory { get; set; } = false;

    [Required]
    public int WorkflowId { get; set; }

    [ForeignKey(nameof(WorkflowId))]
    public Workflow Workflow { get; set; } = null!;

    public int? WorkflowReviewerId { get; set; }

    [ForeignKey(nameof(WorkflowReviewerId))]
    public User? WorkflowReviewer { get; set; }
}
