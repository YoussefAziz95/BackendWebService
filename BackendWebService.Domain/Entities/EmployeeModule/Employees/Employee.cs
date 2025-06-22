using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Employee")]
public class Employee : BaseEntity, IEntity, ITimeModification
{
    public required int UserId { get; set; }
    [ForeignKey("UserId")]
    public required User User { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public StatusEnum AccountStatus { get; set; } = StatusEnum.Pending; // Default status
    public bool IsAvailable { get; set; } // Indicates if the time slot is available for booking
    public RoleEnum Role { get; set; } = RoleEnum.Employee;

}