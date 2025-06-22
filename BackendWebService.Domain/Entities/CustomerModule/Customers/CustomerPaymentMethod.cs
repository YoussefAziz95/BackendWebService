using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
[Table("CustomerPaymentMethod")]
public class CustomerPaymentMethod : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CustomerId { get; set; } // FK to Customer
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }
    [Required]
    public int? ServiceId { get; set; }
    [ForeignKey("ServiceId")]
    public virtual Service? Service { get; set; } // FK to Category
    public int? PropertyId { get; set; }
    [ForeignKey("PropertyId")]
    public virtual Property? Property { get; set; }

    public string? Notes { get; set; }
    public int? VoiceNoteId { get; set; } // FK to File

    [ForeignKey("VoiceNoteId")]
    public virtual FileLog? VoiceNote { get; set; } // FK to File

    public int? FilesId { get; set; }
    [ForeignKey("FilesId")]
    public virtual FileLog? Files { get; set; } // FK to File

    [Required]
    public StatusEnum Status { get; set; } // Enum: Pending, InProgress, Completed, etc.
    [Required, MaxLength(500)]
    public string Description { get; set; }
    [Required]
    public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ScheduledDate { get; set; } // Nullable, if scheduled
    public DateTime? CompletedDate { get; set; } // Nullable, when finished 
}

