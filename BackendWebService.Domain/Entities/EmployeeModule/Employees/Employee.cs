using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Employee")]
public class Employee : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    public StatusEnum AccountStatus { get; set; } = StatusEnum.Pending;

    public bool IsAvailable { get; set; }

    public RoleEnum Role { get; set; } = RoleEnum.Employee;

    // Optional: Track active assignments or linked branches
    public ICollection<EmployeeAssignment>? Assignments { get; set; }
    public ICollection<EmployeeJob>? Jobs { get; set; }
}
