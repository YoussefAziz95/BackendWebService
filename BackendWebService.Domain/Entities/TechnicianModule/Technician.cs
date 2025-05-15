using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;
[Table("Technician")]
public class Technician : BaseEntity, IEntity, ITimeModification
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public StatusEnum AccountStatus { get; set; } = StatusEnum.Pending; // Default status
    public bool IsAvailable { get; set; } // Indicates if the time slot is available for booking
    public RoleEnum Role { get; set; } = RoleEnum.Technician;
    
}