using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("EmployeeJob")]
public class EmployeeJob : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int EmployeeId { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public virtual Employee Employee { get; set; }

    [Required]
    public int JobId { get; set; }

    [ForeignKey(nameof(JobId))]
    public virtual Job Job { get; set; }

    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    public StatusEnum Status { get; set; }

    public DateTime? CompletionDate { get; set; }

    public string? Notes { get; set; }
}
