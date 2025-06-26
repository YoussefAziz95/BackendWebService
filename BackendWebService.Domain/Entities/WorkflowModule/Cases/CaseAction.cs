using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("CaseAction")]
public class CaseAction : BaseEntity, IEntity, ITimeModification
{
    [Range(1, int.MaxValue, ErrorMessage = "Order must be a positive number.")]
    public int? Order { get; set; }

    [ForeignKey(nameof(WorkflowActor))]
    public int? WorkflowActorId { get; set; }
    public User? WorkflowActor { get; set; } // Navigation property (nullable)

    [ForeignKey(nameof(Case))]
    [Required]
    public int CaseId { get; set; }
    public Case Case { get; set; } = null!; // Navigation property

    [ForeignKey(nameof(WorkflowCycle))]
    [Required]
    public int WorkflowCycleId { get; set; }
    public WorkflowCycle WorkflowCycle { get; set; } = null!; // Navigation property

    [Required]
    public int StatusId { get; set; } // Consider using an Enum instead
}
