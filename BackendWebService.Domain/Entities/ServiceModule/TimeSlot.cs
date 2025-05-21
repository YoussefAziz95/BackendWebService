using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ServiceModule;

[Table("TimeSlot")]
public class TimeSlot
{
    public int Id { get; set; } // Unique identifier for the time slot
    public DateTime StartTime { get; set; } // Start time of the time slot
    public DateTime EndTime { get; set; } // End time of the time slot
    [Required]
    public int UserId { get; set; } // Foreign key to the user
    [ForeignKey("UserId")]
    public virtual User User { get; set; } // Navigation property to the user

}

