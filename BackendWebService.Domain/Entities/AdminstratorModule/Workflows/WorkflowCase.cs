using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class WorkflowCase : BaseEntity
{
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "ActionIndex must be a non-negative number.")]
    public int ActionIndex { get; set; }

    [ForeignKey(nameof(Workflow))]
    [Required]
    public int WorkflowId { get; set; }
    public Workflow Workflow { get; set; } = null!; // Navigation property

    [Required]
    public int StatusId { get; set; } // Consider using an Enum for Workflow Status

    [ForeignKey(nameof(CompanySupplier))]
    public int? CompanySupplierId { get; set; } // Nullable if not always required
    public SupplierAccount? CompanySupplier { get; set; } // Navigation property

    [ForeignKey(nameof(User))]
    public int? UserId { get; set; } // Nullable in case it's system-triggered
    public User? User { get; set; } // Navigation property

    public ICollection<WorkflowAction>? WorkflowActions { get; set; }
}
