using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Technician")]
public class Technician : User, IEntity, ITimeModification
{
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public StatusEnum AccountStatus { get; set; } = StatusEnum.Pending; // Default status
    public bool IsAvailable { get; set; } // Indicates if the time slot is available for booking
    public RoleEnum Role { get; set; } = RoleEnum.Technician;

}