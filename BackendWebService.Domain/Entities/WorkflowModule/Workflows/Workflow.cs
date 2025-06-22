using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Workflow : BaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [ForeignKey(nameof(User))]
    public int? UserId { get; set; } // Optional: If workflow is user-specific  
    public User? User { get; set; }  // Navigation property  

    [ForeignKey(nameof(Company))]
    public int? CompanyId { get; set; } // Optional: If workflow belongs to a company  
    public Company? Company { get; set; }  // Navigation property  
    public IList<WorkflowCycle>? WorkflowCycles { get; set; }
}
