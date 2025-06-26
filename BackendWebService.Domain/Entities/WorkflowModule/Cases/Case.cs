using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Case")]
public class Case : BaseEntity, IEntity, ITimeModification
{
    [Required, Range(0, int.MaxValue)]
    public int ActionIndex { get; set; }

    [Required]
    public int WorkflowId { get; set; }

    [ForeignKey(nameof(WorkflowId))]
    public Workflow Workflow { get; set; } = null!;

    [Required]
    public int StatusId { get; set; }

    public int? CompanySupplierId { get; set; }

    [ForeignKey(nameof(CompanySupplierId))]
    public ConsumerAccount? CompanySupplier { get; set; }

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public ICollection<CaseAction>? CaseActions { get; set; }
}
