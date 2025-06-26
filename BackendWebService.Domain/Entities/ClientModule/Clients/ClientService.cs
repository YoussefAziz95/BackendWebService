using Domain;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ClientService")]
public class ClientService : BaseEntity, IEntity, ITimeModification
{
    [Required]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Client Customer { get; set; }

    [Required]
    public int? ServiceId { get; set; }

    [ForeignKey("ServiceId")]
    public Service? Service { get; set; }

    public int? PropertyId { get; set; }

    [ForeignKey("PropertyId")]
    public Property? Property { get; set; }

    public string? Notes { get; set; }

    public int? VoiceNoteId { get; set; }

    [ForeignKey("VoiceNoteId")]
    public FileLog? VoiceNote { get; set; }

    public int? FilesId { get; set; }

    [ForeignKey("FilesId")]
    public FileLog? Files { get; set; }

    public StatusEnum Status { get; set; }

    [Required, MaxLength(500)]
    public string Description { get; set; }

    public DateTime RequestedDate { get; set; } = DateTime.UtcNow;

    public DateTime? ScheduledDate { get; set; }
    public DateTime? CompletedDate { get; set; }
}
