using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("EmployeeJob")]
public class EmployeeJob : BaseEntity, IEntity, ITimeModification
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int JobId { get; set; }
    public DateTime AssignedDate { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Notes { get; set; }
}