using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("CustomerPaymentMethod")]
public class CustomerPaymentMethod : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; }

    [Required]
    public int PaymentMethodId { get; set; }

    [ForeignKey(nameof(PaymentMethodId))]
    public virtual PaymentMethod PaymentMethod { get; set; }

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

    // NEW: Track who last modified it (customer or admin)
    public int? UpdatedByUserId { get; set; }

    [ForeignKey(nameof(UpdatedByUserId))]
    public virtual User? UpdatedByUser { get; set; }
}
