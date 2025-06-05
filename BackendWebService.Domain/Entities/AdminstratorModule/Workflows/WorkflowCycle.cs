using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class WorkflowCycle : BaseEntity
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ActionOrder must be at least 1.")]
    public int ActionOrder { get; set; } // Ensures valid ordering

    [MaxLength(100)]
    public string? ActionType { get; set; } // Optional but limited in length

    public bool Mandatory { get; set; } = false; // Default to non-mandatory

    [ForeignKey(nameof(Workflow))]
    [Required]
    public int WorkflowId { get; set; }
    public Workflow Workflow { get; set; } = null!; // Required navigation property

    [ForeignKey(nameof(WorkflowReviewer))]
    public int? WorkflowReviewerId { get; set; } // Nullable reviewer
    public User? WorkflowReviewer { get; set; } // Navigation property for reviewer
}
