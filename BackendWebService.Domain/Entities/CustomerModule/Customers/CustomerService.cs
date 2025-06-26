using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("CustomerService")]
public class CustomerService : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [ForeignKey(nameof(ServiceId))]
    public virtual Service Service { get; set; }

    public int? PropertyId { get; set; }

    [ForeignKey(nameof(PropertyId))]
    public virtual Property? Property { get; set; }

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public int? VoiceNoteId { get; set; }

    [ForeignKey(nameof(VoiceNoteId))]
    public virtual FileLog? VoiceNote { get; set; }

    public int? FilesId { get; set; }

    [ForeignKey(nameof(FilesId))]
    public virtual FileLog? Files { get; set; }

    [Required]
    public StatusEnum Status { get; set; } = StatusEnum.Pending;

    [Required, MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public DateTime RequestedDate { get; set; } = DateTime.UtcNow;

    public DateTime? ScheduledDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    // Optional: Track who approved or completed the service
    public int? HandledByUserId { get; set; }

    [ForeignKey(nameof(HandledByUserId))]
    public virtual User? HandledByUser { get; set; }
}
